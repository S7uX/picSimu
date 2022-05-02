namespace picSimu.Simulation.Registers;

public class RegisterBit
{
    private Memory _memory;
    public readonly uint Address;
    public readonly int Bit;

    public bool Value
    {
        get => _memory.UnmaskedReadRegister(Address).IsBitSet(Bit);
        set => _memory.UnmaskedWriteRegister(Address, _memory.UnmaskedReadRegister(Address).SetBit(value, Bit));
    }

    public RegisterBit(Memory memory, uint address, int bit)
    {
        _memory = memory;
        Address = address;
        Bit = bit;
    }
}

public class Regsiter
{
    private uint[] _register;
    public readonly uint Address;

    public string Value
    {
        get => _register[Address].ToString("X2");
        set => _register[Address] = Convert.ToUInt32(value, 16);
    }

    public string ToolTip => _register[Address].ToTooltipString();

    public Regsiter(uint[] register, uint address)
    {
        _register = register;
        Address = address;
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