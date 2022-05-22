using System.Text.RegularExpressions;
using picSimu.Simulation;
using picSimu.Simulation.Ports;

namespace picSimu;

public class Register
{
    private Memory _memory;
    public readonly uint Address;
    private static Regex regex = new Regex("^[a-fA-F0-9]{2}$", RegexOptions.Compiled);

    public Register(Memory memory, uint address)
    {
        _memory = memory;
        Address = address;
    }

    public string Value
    {
        get => _memory.Registers[Address].ToString("X2");
        set
        {
            if (regex.IsMatch(value))
            {
                _memory.WriteRegister(Address, Convert.ToUInt32(value, 16));
            }
        }
    }

    public string ToolTip => _memory.Registers[Address].ToTooltip();
}

public class RegisterPair
{
    public Register register0;
    public Register register1;

    public RegisterPair(Register register0, Register register1)
    {
        this.register0 = register0;
        this.register1 = register1;
    }
}

public class RegisterBit
{
    private Memory _memory;
    public readonly uint Address;
    public readonly int Bit;

    public bool Value
    {
        get => _memory.ReadRegister(Address).IsBitSet(Bit);
        set => _memory.WriteRegister(Address, _memory.ReadRegister(Address).SetBit(value, Bit));
    }

    public RegisterBit(Memory memory, uint address, int bit)
    {
        _memory = memory;
        Address = address;
        Bit = bit;
    }
}

public class Breakpoint
{
    private bool[] BreakPoints;
    private int i;

    public bool Value
    {
        get => BreakPoints[i];
        set => BreakPoints[i] = value;
    }


    public Breakpoint(bool[] breakPoints, int i)
    {
        BreakPoints = breakPoints;
        this.i = i;
    }
}

public class PortBit
{
    private readonly Port _port;
    public readonly int Bit;

    public bool Value
    {
        get => _port.ExternalValue.IsBitSet(Bit);
        set => _port.ExternalValue = _port.ExternalValue.SetBit(value, Bit);
    }

    public PortBit(Port port, int bit)
    {
        _port = port;
        Bit = bit;
    }
}