using System.Runtime.InteropServices;
using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic : IDisposable
{
    public uint WRegister = 0;
    public static readonly int ProgramMemoryLength = 512;
    public Instruction[] ProgramMemory { get; private set; } = Array.Empty<Instruction>();
    public bool[] BreakPoints = Array.Empty<bool>();

    public bool ProgramLoaded { get; private set; } = false;
    public Memory Memory;
    public readonly Stack Stack = new Stack(); // 13 bit wide
    private uint _programCounter = 0;
    public bool WDTE = false; // CONFIGURATION WORD: Watchdog Timer Enable bit

    public uint ProgramCounter // 13 bit wide
    {
        get => _programCounter;
        set
        {
            value &= 0b_1_1111_1111_1111;
            value %= (uint) ProgramMemoryLength;
            Memory.Pcl = value;
            _programCounter = value; // clear last 8 bits
        }
    }

    public double Cycles = 0;
    public uint Scaler = 0;
    public double FrequencyInKhz = 4000;
    public uint WatchdogCycles = 0;

    public bool IsSleeping = false;
    private Instruction? _currentInstruction;


    private double _durationOfSingleCycle => 4000 / FrequencyInKhz;
    public int WatchdogTime => (int) (WatchdogCycles * _durationOfSingleCycle);

    public readonly EEPROM EEPROM;

    public Pic()
    {
        new Memory(this);
        EEPROM = new EEPROM(this);

        ResetScaler();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            //_serialHandler = new SerialHandler("COM5", Memory);
            // _serialHandler = new SerialHandler("/dev/ttyUSB0 ", Memory); // Linux
        }
    }

    public CancellationTokenSource? PicRun;
    public bool RunTaskRunning => PicRun is not null;


    #region execution

    public Task Run()
    {
        if (ProgramMemory.Length != 0 && PicRun == null)
        {
            PicRun = new CancellationTokenSource();
            CancellationToken cT = PicRun.Token;

            return Task.Run(async () =>
            {
                await Task.Delay(100, cT);
                bool first = true;
                while (true)
                {
                    if (cT.IsCancellationRequested || (BreakPoints[ProgramCounter] && !first))
                    {
                        break;
                    }

                    first = false;

                    Step();
                }
            }, cT);
        }

        return Task.FromResult<Task?>(null);
    }

    public void StopRun()
    {
        if (PicRun != null)
        {
            PicRun.Cancel();
            PicRun = null;
        }
    }


    public void Step()
    {
        if (!Memory.MclrPin) // Check for MCLEAR
        {
            Memory.MCLR();
        }

        if (!IsSleeping) // STATUS<3>: PD (Check if Pic is sleeping)
        {
            // PD = 1 --> Not sleeping

            _currentInstruction = ProgramMemory[ProgramCounter];
            EEPROM.CheckInstruction(_currentInstruction);
            if (_currentInstruction == null)
            {
                IncreaseProgramCounter(); // NOP
            }
            else
            {
                _currentInstruction.Execute();
                if (_currentInstruction.CycleTwo)
                {
                    _currentInstruction.Execute();
                    _cycle();

                    _currentInstruction.CycleTwo = false;
                }
            }
        }
        else // PD = 0 --> Sleeping
        {
            // do nothing
        }


        EEPROM.CompleteWrite();

        _cycle();
        _wdtCheck();
    }

    #endregion execution


    public void LoadInstructionCodes(InstructionCode[] instructionCodes)
    {
        ProgramMemory = new Instruction[ProgramMemoryLength];

        foreach (InstructionCode instructionCode in instructionCodes)
        {
            int programCounter = instructionCode.ProgramCounter;
            if (programCounter < ProgramMemoryLength)
            {
                ProgramMemory[programCounter] = InstructionDecoder.Decode(instructionCode.Opcode.ToString("X4"), this);
            }
        }

        BreakPoints = new bool[ProgramMemory.Length];
        ProgramLoaded = true;
    }

    private void _wdtCheck()
    {
        if (WDTE)
        {
            double cyclesToGet18Ms = 18000 / _durationOfSingleCycle;
            if (WatchdogCycles > cyclesToGet18Ms)
            {
                WatchdogCycles = 0;
                if (Memory.ReadRegister(0x81).IsBitSet(3)) // OPTION<3> prescaler assigned to WDT?
                {
                    Scaler--;
                    if (Scaler == 0)
                    {
                        ResetScaler();
                        Memory.WatchDogReset();
                    }
                }
                else
                {
                    Memory.WatchDogReset();
                }
            }
        }
    }

    #region timer

    public void ResetScaler()
    {
        Scaler = GetScalerRate();
    }

    public uint GetScalerRate()
    {
        bool PS0 = Memory.ReadRegister(0x81).IsBitSet(0);
        bool PS1 = Memory.ReadRegister(0x81).IsBitSet(1);
        bool PS2 = Memory.ReadRegister(0x81).IsBitSet(2);
        bool PSA = Memory.ReadRegister(0x81).IsBitSet(3);

        if (PSA)
        {
            //assigned to WTD
            if (PS2 && PS1 && PS0) return 128;
            if (PS2 && PS1 && !PS0) return 64;
            if (PS2 && !PS1 && PS0) return 32;
            if (PS2 && !PS1 && !PS0) return 16;
            if (!PS2 && PS1 && PS0) return 8;
            if (!PS2 && PS1 && !PS0) return 4;
            if (!PS2 && !PS1 && PS0) return 2;
            if (!PS2 && !PS1 && !PS0) return 1;
        }
        else
        {
            //assigned to Timer0
            if (PS2 && PS1 && PS0) return 256;
            if (PS2 && PS1 && !PS0) return 128;
            if (PS2 && !PS1 && PS0) return 64;
            if (PS2 && !PS1 && !PS0) return 32;
            if (!PS2 && PS1 && PS0) return 16;
            if (!PS2 && PS1 && !PS0) return 8;
            if (!PS2 && !PS1 && PS0) return 4;
            if (!PS2 && !PS1 && !PS0) return 2;
        }

        throw new IndexOutOfRangeException();
    }

    public void TimerStep()
    {
        if (!Memory.ReadRegister(0x81).IsBitSet(3)) // OPTION<3> if prescaler is assigned to TMR0
        {
            Scaler--;
            if (Scaler == 0)
            {
                ResetScaler();
                IncreaseTimer();
            }
        }
        else
        {
            IncreaseTimer();
        }
    }

    private void IncreaseTimer()
    {
        uint value = Memory.ReadRegister(1); // Get Current Timer value
        value++; // increase it
        if (value > 255) // Check if it overflows
        {
            // Overflow
            value &= 255; // Mask to 8 bits

            // Check if Timer0 interrupt is enabled
            if (Memory.ReadRegister(0x0B).IsBitSet(5)) // T01E
            {
                // Interrupt is NOT masked
                Interrupt();
                Memory.WriteRegister(0x0B, Memory.ReadRegister(0x0B).SetBitTo1(2)); // T0IF INTCON<4>: Set Flag that TMR0 interrupt occured
            }
        }

        Memory.WriteRegister(0x01, value);
    }

    public void Interrupt()
    {
        if (Memory.ReadRegister(0x0B).IsBitSet(7)) // GIE bit INTCON<7>
        {
            if (_currentInstruction != null && _currentInstruction.CycleTwo)
            {
                _currentInstruction.CycleTwo = false;
            }

            Stack.Push(ProgramCounter);
            ProgramCounter = 4; // interrupt vector
            Memory.WriteRegister(0x02, 0b_00000100); // PCL
            Memory.WriteRegister(0x0A, 0b_00000000); // PCLATH
        }
        else
        {
            if (IsSleeping)
            {
                Memory.WriteRegister(0x03, Memory.ReadRegister(0x03)
                    .SetBitTo1(4) // TO
                    .SetBitTo0(3)
                ); // PD STATUS<3>); // STATUS
                IsSleeping = false;
            }
        }
    }

    public double CalculateRuntime()
    {
        return 4000 / FrequencyInKhz * Cycles; // µs
    }

    #endregion timer

    public void IncreaseProgramCounter()
    {
        ProgramCounter++;
    }

    private void _cycle()
    {
        Cycles++;
        if (!Memory.ReadRegister(0x81).IsBitSet(5)) // OPTION_REG<5> - Timer mode is selected by clearing the T0CS bit
        {
            TimerStep();
        }

        if (WDTE)
        {
            WatchdogCycles++; // Increase Watchdog Counter
        }
    }

    #region blazor data binding

    public Breakpoint GetBreakPoint(int i)
    {
        return new Breakpoint(BreakPoints, i);
    }

    #endregion blazor data binding

    public void Dispose()
    {
        StopRun();
    }
}