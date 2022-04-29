namespace picSimu.Simulation.Registers;

public class RegisterBit
{
    private Memory _memory;
    public readonly uint Address;
    public readonly int Bit;

    public bool Value
    {
        get { return _memory.ReadRegister(Address).IsBitSet(Bit); }
        set { _memory.WriteRegister(Address, _memory.ReadRegister(Address).SetBit(value, Bit)); }
    }

    public RegisterBit(Memory memory, uint address, int bit)
    {
        _memory = memory;
        Address = address;
        Bit = bit;
    }
}