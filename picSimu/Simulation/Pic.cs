using picSimu.Simulation.Instructions;
using picSimu.Simulation.Registers;

namespace picSimu.Simulation;

public class Pic
{
    public static readonly int ProgramMemoryLength = 1024;
    public uint WRegister;
    public uint Runtime;
    public uint Scaler;

    public Instruction[] ProgramMemory { get; private set; }
    public bool ProgramLoaded { get; private set; }

    public bool[] BreakPoints = Array.Empty<bool>();

    public readonly Memory Memory;

    public readonly CircularStack Stack;
    

    public Pic()
    {
        ProgramMemory = Array.Empty<Instruction>();
        ProgramLoaded = false;
        Stack = new CircularStack(8);
        Memory = new Memory();
        WRegister = 0;
        Runtime = 0;
        Scaler = 0;
        ResetScaler();
    }

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

    public void ResetScaler()
    {
        Scaler = GetScaler();
    }

    public uint GetScaler()
    {
        bool PS0 = Memory.UnmaskedReadRegister(0x81).IsBitSet(0);
        bool PS1 = Memory.UnmaskedReadRegister(0x81).IsBitSet(1);
        bool PS2 = Memory.UnmaskedReadRegister(0x81).IsBitSet(2);
        bool PSA = Memory.UnmaskedReadRegister(0x81).IsBitSet(3);
        if (PSA == true)
        {
            //assigned to WDT
            if (PS2 && PS1 && PS0)
            {
                return 128;
            }
            else if (PS2 && PS1 && !PS0)
            {
                return 64;
            }
            else if (PS2 && !PS1 && PS0)
            {
                return 32;
            }
            else if (PS2 && !PS1 && !PS0)
            {
                return 16;
            }
            else if (!PS2 && PS1 && PS0)
            {
                return 8;
            }
            else if (!PS2 && PS1 && !PS0)
            {
                return 4;
            }
            else if (!PS2 && !PS1 && PS0)
            {
                return 2;
            }
            else if (!PS2 && !PS1 && !PS0)
            {
                return 1;
            }
        }
        else
        {
            //assigned to Timer0
            if (PS2 && PS1 && PS0)
            {
                return 256;
            }
            else if (PS2 && PS1 && !PS0)
            {
                return 128;
            }
            else if (PS2 && !PS1 && PS0)
            {
                return 64;
            }
            else if (PS2 && !PS1 && !PS0)
            {
                return 32;
            }
            else if (!PS2 && PS1 && PS0)
            {
                return 16;
            }
            else if (!PS2 && PS1 && !PS0)
            {
                return 8;
            }
            else if (!PS2 && !PS1 && PS0)
            {
                return 4;
            }
            else if (!PS2 && !PS1 && !PS0)
            {
                return 2;
            }
        }

        throw new IndexOutOfRangeException();
    }

    public void IncreaseProgramCounter()
    {
        uint pc = Memory.ReadRegister(2);
        pc++;
        pc &= 255;
        Memory.WriteRegister(2, pc);

        Runtime++;
        Scaler--;
        if (Scaler == 0)
        {
            ResetScaler();
            bool PSA = Memory.UnmaskedReadRegister(0x81).IsBitSet(3);
            if (PSA == true)
            {
                //WDT  
            }
            else
            {
                //Timer0
                IncreaseTimer();
            }
        }
    }

    private void IncreaseTimer()
    {
        var value = Memory.ReadRegister(1);
        value++;
        value &= 255;
        Memory.WriteRegister(1, value);
    }

    public double GetRuntime()
    {
        double frequenzInMhz = 4;
        double result = 4 / frequenzInMhz * Runtime;
        return result;
    }

    public void Run(CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            await Task.Delay(100);
            while (true)
            {
                if (BreakPoints[Memory.ReadRegister(2)] || cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                ProgramMemory[Memory.ReadRegister(2)].Execute();
            }
        }, cancellationToken);
    }

    public void Step()
    {
        ProgramMemory[Memory.ReadRegister(2)].Execute();
    }

    public void HardwareReset()
    {
    }

    public Breakpoint GetBreakPoint(int i)
    {
        return new Breakpoint(BreakPoints, i);
    }
}