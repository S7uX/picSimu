namespace picSimu.Simulation;

public class Ports
{
    private readonly Memory _memory;
    private uint _port;

    private const uint PortARegisterAddress = 5;
    private const uint TrisARegisterAddress = 0x85;
    private const uint PortBRegisterAddress = 6;
    private const uint TrisBRegisterAddress = 0x86;

    public Ports(Memory memory)
    {
        _memory = memory;
    }

    /// <summary>
    /// first 3 bits unimpelemented
    /// </summary>
    public uint AExternalValue
    {
        get => GetValue(TrisARegisterAddress, PortARegisterAddress) & 0b_00011111;
        set
        {
            value &= 0b_00011111;
            SetExternalValue(TrisARegisterAddress, PortARegisterAddress, value);
        }
    }

    public uint AInternalValue
    {
        get => BExternalValue;
        set => SetInternalValue(TrisBRegisterAddress, PortBRegisterAddress, value);
    }

    public uint BExternalValue
    {
        get => GetValue(TrisBRegisterAddress, PortBRegisterAddress);
        set => SetExternalValue(TrisBRegisterAddress, PortBRegisterAddress, value);
    }

    public uint BInternalValue
    {
        get => BExternalValue;
        set => SetInternalValue(TrisBRegisterAddress, PortBRegisterAddress, value);
    }


    public uint GetValue(uint trisAddress, uint portAddress)
    {
        uint trisReg = _memory.Registers[trisAddress];
        uint latch = _memory.Registers[portAddress];

        for (int i = 0; i <= 7; i++)
        {
            if (!trisReg.IsBitSet(i)) // 0: output
            {
                _port = _port.SetBit(latch.IsBitSet(i), i);
            }
        }

        return _port;
    }

    public void SetExternalValue(uint trisRegisterAddress, uint portRegisterAddress, uint value)
    {
        uint trisReg = _memory.Registers[trisRegisterAddress];
        uint portReg = _memory.Registers[portRegisterAddress];

        for (int i = 0; i <= 7; i++)
        {
            if (trisReg.IsBitSet(i)) // 1: input
            {
                _port = _port.SetBit(value.IsBitSet(i), i);
            }
            else // 0: output
            {
                _port = _port.SetBit(portReg.IsBitSet(i), i);
            }
        }

        _memory.Registers[portRegisterAddress] = portReg;
    }


    public void SetInternalValue(uint trisRegisterAddress, uint portRegisterAddress, uint value)
    {
        uint trisReg = _memory.Registers[trisRegisterAddress];
        uint portReg = _memory.Registers[portRegisterAddress];

        for (int i = 0; i <= 7; i++)
        {
            if (trisReg.IsBitSet(i)) // 1: input
            {
                _port = _port.SetBit(value.IsBitSet(i), i);
            }
            else // 0: output
            {
                _port = _port.SetBit(portReg.IsBitSet(i), i);
            }
        }

        _memory.Registers[portRegisterAddress] = portReg;
    }
}

public class PortABit
{
    private readonly Ports _ports;
    public readonly int Bit;

    public bool Value
    {
        get => _ports.AExternalValue.IsBitSet(Bit);
        set => _ports.AExternalValue = _ports.BExternalValue.SetBit(value, Bit);
    }

    public PortABit(Ports ports, int bit)
    {
        _ports = ports;
        Bit = bit;
    }
}

public class PortBBit
{
    private readonly Ports _ports;
    public readonly int Bit;

    public bool Value
    {
        get => _ports.BExternalValue.IsBitSet(Bit);
        set => _ports.BExternalValue = _ports.BExternalValue.SetBit(value, Bit);
    }

    public PortBBit(Ports ports, int bit)
    {
        _ports = ports;
        Bit = bit;
    }
}