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