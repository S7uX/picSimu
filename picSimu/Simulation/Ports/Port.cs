namespace picSimu.Simulation;

public class Port
{
    protected readonly Memory Memory;
    protected readonly Pic Pic;
    protected uint PortValue;

    public readonly uint PortRegisterAddress;
    public readonly uint TrisRegisterAddress;
    public readonly uint Length;
    protected readonly uint Mask;

    public Port(Pic pic, uint portRegisterAddress, uint trisRegisterAddress, uint length)
    {
        Memory = pic.Memory;
        PortRegisterAddress = portRegisterAddress;
        TrisRegisterAddress = trisRegisterAddress;
        Length = length;
        Pic = pic;
        Mask = (uint) Math.Pow(2, Length) - 1;
    }

    /// <summary>
    /// first 3 bits unimpelemented
    /// </summary>
    public virtual uint ExternalValue
    {
        get => GetValue() & Mask;
        set
        {
            value &= Mask;

            uint trisReg = Memory.Registers[TrisRegisterAddress];
            uint portReg = Memory.Registers[PortRegisterAddress];

            for (int i = 0; i <= 7; i++)
            {
                if (trisReg.IsBitSet(i)) // 1: input
                {
                    PortValue = PortValue.SetBit(value.IsBitSet(i), i);
                }
                else // 0: output
                {
                    PortValue = PortValue.SetBit(portReg.IsBitSet(i), i);
                }
            }

            Memory.Registers[PortRegisterAddress] = portReg;
        }
    }

    public uint InternalValue
    {
        get => ExternalValue;
        set
        {
            value &= Mask;
            uint trisReg = Memory.Registers[TrisRegisterAddress];
            uint portReg = Memory.Registers[PortRegisterAddress];

            for (int i = 0; i <= 7; i++)
            {
                if (trisReg.IsBitSet(i)) // input
                {
                    portReg = portReg.SetBit(value.IsBitSet(i), i);
                }
                else // output
                {
                    portReg = portReg.SetBit(value.IsBitSet(i), i);
                    PortValue = PortValue.SetBit(portReg.IsBitSet(i), i);
                }
            }

            Memory.Registers[PortRegisterAddress] = portReg;
        }
    }


    protected uint GetValue()
    {
        uint trisReg = Memory.Registers[TrisRegisterAddress];
        uint latch = Memory.Registers[PortRegisterAddress];

        for (int i = 0; i <= 7; i++)
        {
            if (!trisReg.IsBitSet(i)) // 0: output
            {
                PortValue = PortValue.SetBit(latch.IsBitSet(i), i);
            }
        }

        return PortValue;
    }
}