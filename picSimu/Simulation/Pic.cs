using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic
{
    public uint wRegister = 0;
    public uint Programmcounter = 0;
    public uint Runtime = 0;
    public uint Scaler = 0;

    private Instruction[] _programMemory;
    public Instruction[] ProgramMemory => _programMemory;
    public bool[] BreakPoints = Array.Empty<bool>();

    public readonly Memory Memory;

    public CircularStack Stack;

    public Pic()
    {
        _programMemory = new Instruction[1024];
        Stack = new CircularStack(8);
        Memory = new Memory();
        ResetScaler();
    }

    public void LoadInstructionCodes(string[] hexStrings)
    {
        int i = 0;
        foreach (var hexString in hexStrings)
        {
            _programMemory[i] = InstructionDecoder.Decode(hexString, this);
            i++;
        }

        BreakPoints = new bool[_programMemory.Length];
    }

    public void ResetScaler()
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
                Scaler = 128;
            }
            else if (PS2 && PS1 && !PS0)
            {
                Scaler = 64;
            }
            else if (PS2 && !PS1 && PS0)
            {
                Scaler = 32;
            }
            else if (PS2 && !PS1 && !PS0)
            {
                Scaler = 16;
            }
            else if (!PS2 && PS1 && PS0)
            {
                Scaler = 8;
            }
            else if (!PS2 && PS1 && !PS0)
            {
                Scaler = 4;
            }
            else if (!PS2 && !PS1 && PS0)
            {
                Scaler = 2;
            }
            else if (!PS2 && !PS1 && !PS0)
            {
                Scaler = 1;
            }
        }
        else
        {
            //assigned to Timer0
            if (PS2 && PS1 && PS0)
            {
                Scaler = 256;
            }
            else if (PS2 && PS1 && !PS0)
            {
                Scaler = 128;
            }
            else if (PS2 && !PS1 && PS0)
            {
                Scaler = 64;
            }
            else if (PS2 && !PS1 && !PS0)
            {
                Scaler = 32;
            }
            else if (!PS2 && PS1 && PS0)
            {
                Scaler = 16;
            }
            else if (!PS2 && PS1 && !PS0)
            {
                Scaler = 8;
            }
            else if (!PS2 && !PS1 && PS0)
            {
                Scaler = 4;
            }
            else if (!PS2 && !PS1 && !PS0)
            {
                Scaler = 2;
            }
        }
    }
    public void IncreaseProgramCounter()
    {
        Programmcounter++;
        Programmcounter &= 255;
        
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
        Memory.WriteRegister(1, ++value);
    }

    public void Run()
    {
        //TODO
    }

    public void Step()
    {
        _programMemory[Programmcounter].Execute();
    }

    public void Stop()
    {
        //TODO
    }

    public Breakpoint GetBreakPoint(int i)
    {
        return new Breakpoint(BreakPoints, i);
    }
}

public class Breakpoint
{
    private bool[] BreakPoints;
    private int i;
    
    public bool Value { get => BreakPoints[i]; set => BreakPoints[i] = value; }


    public Breakpoint(bool[] breakPoints, int i)
    {
        BreakPoints = breakPoints;
        this.i = i;
    }
}