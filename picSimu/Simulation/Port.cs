namespace picSimu.Simulation;

public class Port
{
    private Memory _memory;
    private readonly uint _portRegisterAddress;
    private readonly uint _trisRegisterAddress;
    private uint _port;

    public Port(Memory memory, uint portRegisterAddress, uint trisRegisterAddress)
    {
        _portRegisterAddress = portRegisterAddress;
        _trisRegisterAddress = trisRegisterAddress;
        _memory = memory;
    }

    public uint ExternalValue
    {
        get
        {
            uint trisReg = _memory.Registers[_trisRegisterAddress];
            uint latch = _memory.Registers[_portRegisterAddress];

            for (int i = 0; i <= 7; i++)
            {
                if (!trisReg.IsBitSet(i)) // 0: output
                {
                    _port = _port.SetBit(latch.IsBitSet(i), i);
                }
            }

            return _port;
        }
        set
        {
            uint trisReg = _memory.Registers[_trisRegisterAddress];
            uint portReg = _memory.Registers[_portRegisterAddress];
            
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

            _memory.Registers[_portRegisterAddress] = portReg;
        }
    }

    public uint InternalValue
    {
        get => ExternalValue;
        set
        {
            uint trisReg = _memory.Registers[_trisRegisterAddress];
            uint portReg = _memory.Registers[_portRegisterAddress];

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

            _memory.Registers[_portRegisterAddress] = portReg;
        }
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