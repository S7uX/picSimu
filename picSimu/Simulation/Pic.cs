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
    public readonly Memory Memory;
    public readonly Stack Stack = new Stack(); // 13 bit wide
    private uint _programCounter = 0;
    public bool ReleaseWatchdog { get; set; }

    public uint ProgramCounter // 13 bit wide
    {
        get => _programCounter;
        set
        {
            value &= 0b_1_1111_1111_1111;
            Pcl = value;
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

    public bool MCLR; // low active
    public EEPROM EEPROM;

    public Pic()
    {
        Memory = new Memory(this);
        EEPROM = new EEPROM(this);

        ResetScaler();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _serialHandler = new SerialHandler("COM2", Memory);
        }
    }


    #region execution

    public async Task Run(CancellationToken cancellationToken)
    {
        await Task.Run(async () =>
        {
            await Task.Delay(100, cancellationToken);
            while (true)
            {
                if (BreakPoints[ProgramCounter] || cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                ProgramMemory[ProgramCounter].Execute();
            }
        }, cancellationToken);
    }

    public void Step()
    {
        ProgramMemory[ProgramCounter].Execute();
        _serialHandler?.Write();
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
        Scaler = GetScaler();
    }

    public uint GetScaler()
    {
        bool PS0 = Memory.ReadRegister(0x81).IsBitSet(0);
        bool PS1 = Memory.ReadRegister(0x81).IsBitSet(1);
        bool PS2 = Memory.ReadRegister(0x81).IsBitSet(2);
        bool PSA = Memory.ReadRegister(0x81).IsBitSet(3);

        if (PSA)
        {
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

    private void IncreaseTimer()
    {
        uint value = Memory.ReadRegister(1);
        value++;
        value &= 255;
        Memory.WriteRegister(0x01, value);
    }

    public double CalculateRuntime()
    {
        // return 4 / FrequencyInMhz * Cycles; // µs
        return ((Cycles * 4) / FrequencyInKhz) * 1000; // µs
    }

    #endregion timer

    public void IncreaseProgramCounter()
    {
        ProgramCounter++;

        Cycles++;
        Scaler--;
        if (Scaler == 0)
        {
            ResetScaler();
            IncreaseTimer();
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
    }
}