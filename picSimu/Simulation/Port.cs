namespace picSimu.Simulation;

public class Port
{
    private readonly Memory _memory;
    private uint _port;

    public readonly uint PortRegisterAddress;
    public readonly uint TrisRegisterAddress;
    public readonly uint Length;
    private readonly uint _mask;

    public Port(Memory memory, uint portRegisterAddress, uint trisRegisterAddress, uint length)
    {
        _memory = memory;
        PortRegisterAddress = portRegisterAddress;
        TrisRegisterAddress = trisRegisterAddress;
        Length = length;
        _mask = (uint) Math.Pow(2, Length) - 1;
    }

    /// <summary>
    /// first 3 bits unimpelemented
    /// </summary>
    public uint ExternalValue
    {
        get => GetValue() & _mask;
        set
        {
            value &= _mask;
            SetExternalValue(value);
        }
    }

    public uint InternalValue
    {
        get => ExternalValue & _mask;
        set
        {
            value &= _mask;
            SetInternalValue(value);
        }
    }


    public uint GetValue()
    {
        uint trisReg = _memory.Registers[TrisRegisterAddress];
        uint latch = _memory.Registers[PortRegisterAddress];

        for (int i = 0; i <= 7; i++)
        {
            if (!trisReg.IsBitSet(i)) // 0: output
            {
                _port = _port.SetBit(latch.IsBitSet(i), i);
            }
        }

        return _port;
    }

    public void SetExternalValue(uint value)
    {
        uint trisReg = _memory.Registers[TrisRegisterAddress];
        uint portReg = _memory.Registers[PortRegisterAddress];

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

        _memory.Registers[PortRegisterAddress] = portReg;
    }


    public void SetInternalValue(uint value)
    {
        uint trisReg = _memory.Registers[TrisRegisterAddress];
        uint portReg = _memory.Registers[PortRegisterAddress];
        
        for (int i = 0; i <= 7; i++)
        {
            if (trisReg.IsBitSet(i)) // input
            {
                portReg = portReg.SetBit(value.IsBitSet(i), i);
            }
            else // output
            {
                portReg = portReg.SetBit(value.IsBitSet(i), i);
                _port = _port.SetBit(portReg.IsBitSet(i), i);
            }
        }

        _memory.Registers[PortRegisterAddress] = portReg;
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