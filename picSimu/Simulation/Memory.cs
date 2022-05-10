using picSimu.Simulation.Registers;

namespace picSimu.Simulation;

public class Memory
{
    public readonly uint[] Registers = new uint[256];
    public readonly Port PortA;
    public readonly Port PortB;

    public Memory()
    {
        PortA = new Port(this, 5, 0x85);
        PortB = new Port(this, 6, 0x86);
    }

    public bool BankSelect()
    {
        return Lib.IsBitSet(Registers[3], 5);
    }

    public uint FSR => Registers[4];

    public void SetCarryFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 0));
    }

    public bool GetCarryFlag()
    {
        return Lib.IsBitSet(ReadRegister(3), 0);
    }

    public void SetDigitCarryFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 1));
    }

    public bool GetDigitCarryFlag()
    {
        return Lib.IsBitSet(ReadRegister(3), 1);
    }

    public void SetZeroFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 2));
    }

    public bool GetZeroFlag()
    {
        return Lib.IsBitSet(ReadRegister(3), 2);
    }

    public uint MaskAddress(uint address)
    {
        if (!BankSelect())
        {
            // bank 0
            return address.SetBitTo0(7);
        }
        else
        {
            // bank 1
            return address.SetBitTo1(7);
        }
    }


    public uint ReadRegister(uint address)
    {
        return UnmaskedReadRegister(MaskAddress(address));
    }

    public uint UnmaskedReadRegister(uint address)
    {
        if ((0x30 <= address && 0x7F >= address) || (0xD0 <= address && 0xFF >= address) || address == 7) // Unimplemented data memory location; read as ’0’.
        {
            return 0;
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                if (FSR == 0) return 0; // prevent infinite loop
                return UnmaskedReadRegister(Registers[4]);
            case 2: // pcl
            case 0x82:
                return Registers[2];
            case 3: // status
            case 0x83:
                return Registers[3];
            case 4: // fsr
            case 0x84:
                return Registers[4];
            case 5:
                return PortA.InternalValue;
            case 6:
                return PortB.InternalValue;
            case 0x0A: // pclath
            case 0x8A:
                return Registers[0x0A];
            case 0x0B: // intcon
            case 0X8B:
                return Registers[0x0B];
        }

        return Registers[address];
    }

    public void WriteRegister(uint address, uint value)
    {
        UnmaskedWriteRegister(MaskAddress(address), value);
    }

    public void UnmaskedWriteRegister(uint address, uint value)
    {
        if ((0x30 <= address && 0x7F >= address) || (0xD0 <= address && 0xFF >= address) || address == 7) // Unimplemented data memory location; do nothing
        {
            return;
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                if (FSR == 0) return; // prevent infinite loop
                UnmaskedWriteRegister(Registers[4], value);
                return;
            case 2: // pcl
            case 0x82:
                Registers[2] = value;
                Registers[0x82] = value;
                return;
            case 3: // status
            case 0x83:
                Registers[3] = value;
                Registers[0x83] = value;
                return;
            case 4: // fsr
            case 0x84:
                Registers[4] = value;
                Registers[0X84] = value;
                return;
            case 5:
                PortA.InternalValue = value;
                return;
            case 6:
                PortB.InternalValue = value;
                return;
            case 0x0A: // pclath
            case 0x8A:
                Registers[0x0A] = value;
                Registers[0x8A] = value;
                return;
            case 0x0B: // intcon
            case 0x8B:
                Registers[0x0B] = value;
                Registers[0x8B] = value;
                return;
        }

        Registers[address] = value;
    }

    public RegisterBit GetRegisterBit(uint address, int bit)
    {
        return new RegisterBit(this, address, bit);
    }

    public Register GetRegister(uint address)
    {
        return new Register(this, address);
    }
}