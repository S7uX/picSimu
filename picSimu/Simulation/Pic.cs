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
    public bool ReleaseWatchdog { get; set; }

    public uint ProgramCounter // 13 bit wide
    {
        get => _programCounter;
        set
        {
            value &= 0b_1_1111_1111_1111;
            Pcl = value % (uint) ProgramMemoryLength;
            _programCounter = value; // clear last 8 bits
        }
    }

    public uint Pcl // 8-bits wide
    {
        get => Memory.ReadRegister(2) & 0b_1111_1111;
        set => Memory.WriteRegister(2, value & 0b_1111_1111);
    }

    public double Cycles = 0;
    public uint Scaler = 0;
    public double FrequencyInKhz = 4000;
    private SerialHandler? _serialHandler;
    private uint WatchdogCycleCounter = 0;

    public EEPROM EEPROM;

    public Pic()
    {
        new Memory(this);
        EEPROM = new EEPROM(this);

        ResetScaler();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _serialHandler = new SerialHandler("COM5", Memory);
            // _serialHandler = new SerialHandler("/dev/ttyUSB0 ", Memory); // Linux
        }
    }

    public CancellationTokenSource? PicRun;
    public bool IsRunning => PicRun is not null;


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
                    if ((BreakPoints[ProgramCounter] || cT.IsCancellationRequested) && !first)
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
        if (!Memory.MCLRPIN) // Check for MCLEAR
        {
            MCLR();
        }

        WatchdogCycleCounter++; // Increase Watchdog Counter

        if (Memory.ReadRegister(0x83).IsBitSet(0x3)) // STATUS<3>: PD (Check if Pic is sleeping)
        {
            // PD = 1 --> Not sleeping

            EEPROM.CheckInstruction(ProgramMemory[ProgramCounter]);
            ProgramMemory[ProgramCounter].Execute();
            _serialHandler?.Write();
        }
        else // PD = 0 --> Sleeping
        {
            Cycles++;
            var DurationOfSingleCycle = 4000 / FrequencyInKhz; // vier Quatztakte; *1000 --> µs
            var CyclesToGet18MS = 18000 / DurationOfSingleCycle;
            if (WatchdogCycleCounter > CyclesToGet18MS)
            {
                WatchdogCycleCounter = 0;
                Scaler--;
                if (Scaler == 0)
                {
                    ResetScaler();
                    IncreaseTimer();
                    Memory.WriteRegister(0x83, Memory.ReadRegister(0x83).SetBitTo1(3)); // Wake UP --> PD (STATUS<3>) = 1
                }
            }
        }

        EEPROM.CompleteWrite();
    }

    private void MCLR()
    {
        ProgramCounter = 0;
        Memory.WriteRegister(0x02, 0b_00000000); //PCL
        var status = Memory.ReadRegister(0x03);
        status.SetBitTo0(7);
        status.SetBitTo0(6);
        status.SetBitTo0(5);
        Memory.WriteRegister(0x03, status); //STATUS
        Memory.WriteRegister(0x0A, 0b_00000000); //PCLATH
        var intcon = Memory.ReadRegister(0x0B);
        intcon.SetBitTo0(7);
        intcon.SetBitTo0(6);
        intcon.SetBitTo0(5);
        intcon.SetBitTo0(4);
        intcon.SetBitTo0(3);
        intcon.SetBitTo0(2);
        intcon.SetBitTo0(1);
        Memory.WriteRegister(0x02, intcon); //INTCON
        Memory.WriteRegister(0x85, 0b_00011111); //TRISA
        Memory.WriteRegister(0x86, 0b_11111111); //TRISB
        var eecon_1 = Memory.ReadRegister(0x0B);
        eecon_1.SetBitTo0(0);
        eecon_1.SetBitTo0(1);
        eecon_1.SetBitTo0(2);
        eecon_1.SetBitTo0(4);
        Memory.WriteRegister(0x0B, eecon_1); //EECON_1
    }

    #endregion execution


    public void LoadInstructionCodes(string[] hexStrings)
    {
        int i = 0;
        ProgramMemory = new Instruction[ProgramMemoryLength];
        foreach (string hexString in hexStrings)
        {
            ProgramMemory[i] = InstructionDecoder.Decode(hexString, this);
            i++;
        }

        BreakPoints = new bool[ProgramMemory.Length];
        ProgramLoaded = true;
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
        if (!Memory.ReadRegister(0x81).IsBitSet(3)) // OPTION<3> If Prescaler is assgined to TMR0
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

            // Check if Timer0Interupt is enabled
            if (Memory.ReadRegister(0x0B).IsBitSet(5)) // T01E
            {
                // Interrupt is NOT masked
                Stack.Push(ProgramCounter);
                ProgramCounter = 4; // interrupt vector
                Memory.WriteRegister(0x02, 0b_00000100); // PCL
                Memory.WriteRegister(0x0A, 0b_00000000); // PCLatch
                Memory.WriteRegister(0x0B, Memory.ReadRegister(0x0B).SetBitTo1(2)); // Set Flag that Interrupt occured
            }
        }

        Memory.WriteRegister(0x01, value);
    }

    public double CalculateRuntime()
    {
        return 4000 / FrequencyInKhz * Cycles; // µs
    }

    #endregion timer

    public void IncreaseProgramCounter()
    {
        ProgramCounter++;

        Cycles++;
        if (!Memory.ReadRegister(0x81).IsBitSet(5)) // OPTION_REG<5> - Timer mode is selected by clearing the T0CS bit
        {
            TimerStep();
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
        _serialHandler?.Dispose();
        StopRun();
    }
}