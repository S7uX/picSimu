using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace picSimu.Simulation.Registers;

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

public class Register
{
    private Memory _memory;
    public readonly uint Address;
    private static Regex regex = new Regex("^[a-fA-F0-9]{2}$", RegexOptions.Compiled);

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

    public string ToolTip => _memory.Registers[Address].ToTooltipString();

    public Register(Memory memory, uint address)
    {
        _memory = memory;
        Address = address;
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