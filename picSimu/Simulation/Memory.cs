using picSimu.Simulation.Registers;

namespace picSimu.Simulation;

public class Memory
{
    private Pic _pic;
    public readonly uint[] Registers = new uint[256];
    public readonly Ports Ports;

    public Memory(Pic pic)
    {
        _pic = pic;
        Ports = new Ports(this);
        PowerOnReset();
    }

    public bool BankSelect()
    {
        return Lib.IsBitSet(Registers[3], 5);
    }

    public bool IsSleeping()
    {
        return Lib.IsBitSet(Registers[3], 5);
    }

    public void PowerOnReset()
    {
        UnmaskedWriteRegister(0x03, 0b_00011000);
        UnmaskedWriteRegister(0x81, 0b_11111111);
        UnmaskedWriteRegister(0x83, 0b_00011000);
        UnmaskedWriteRegister(0x85, 0b_00011111); // tris a
        UnmaskedWriteRegister(0x86, 0b_11111111); // tris b
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
                return Ports.AInternalValue;
            case 0x85: // Tris a
                return Registers[0x85] & 0b_00011111;
            case 6:
                return Ports.BInternalValue;
            case 0x86: // Tris b
                return Registers[0x86];
            case 0x0A: // pclath
            case 0x8A:
                return Registers[0x0A] & 0b_00011111;
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
            case 1: //TIMER0
                if (!Lib.IsBitSet(ReadRegister(0x81), 3))
                {
                    //IF Prescaler is assigned to TMR0 (PSA = 0)
                    _pic.ResetScaler();
                }

                Registers[1] = value;
                return;
            case 2: // pcl; low byte program counter
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
                Ports.AInternalValue = value;
                return;
            case 0x85: // tris a
                Registers[0x85] = value & 0b_00011111;
                return;
            case 6:
                Ports.BInternalValue = value;
                return;
            case 0x86: // tris b
                Registers[0x86] = value;
                return;
            case 0x0A: // pclath
            case 0x8A:
                // first three unimplemented
                Registers[0x0A] = value & 0b_00011111;
                Registers[0x8A] = value & 0b_00011111;
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