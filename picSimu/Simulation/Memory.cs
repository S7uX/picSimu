namespace picSimu.Simulation;

public class Memory
{
    public readonly uint[] Register = new uint[256];

    public bool BankSelect()
    {
        return Lib.IsBitSet(Register[3], 5);
    }

    public void SetCarryFlag(bool zeroFlag)
    {
        WriteRegister(0, ReadRegister(3).SetBit(zeroFlag, 0));
    }

    public bool GetCarryFlag()
    {
        return Lib.IsBitSet(ReadRegister(3), 0);
    }

    public void SetDigitCarryFlag(bool zeroFlag)
    {
        WriteRegister(1, ReadRegister(3).SetBit(zeroFlag, 1));
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


    public uint ReadRegister(uint address)
    {
        if (!BankSelect())
        {
            // bank 0
            address = address.SetBitTo0(7);
            if (0x30 <= address || address == 7) // Unimplemented data memory location; read as ’0’.
            {
                return 0;
            }
        }
        else
        {
            // bank 1
            address = address.SetBitTo1(7);
            if (0xD0 <= address || address == 0x87) // Unimplemented data memory location; read as ’0’.
            {
                return 0;
            }
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                return Register[0];
            case 2: // pcl
            case 0x82:
                return Register[2];
            case 3: // status
            case 0x83:
                return Register[3];
            case 4: // fsr
            case 0x84:
                return Register[4];
            case 0x0A: // pclath
            case 0x8A:
                return Register[0x0A];
            case 0x0B: // intcon
            case 0X8B:
                return Register[0x0B];
        }

        return Register[address];
    }

    public void WriteRegister(uint address, uint value)
    {
        if (!BankSelect())
        {
            // bank 0
            address = address.SetBitTo0(7);
            if (0x30 <= address || address == 7)
            {
                return;
            }
        }
        else
        {
            // bank 1
            address = address.SetBitTo1(7);
            if (0xD0 <= address || address == 0x87)
            {
                return;
            }
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                Register[0] = value;
                Register[0x80] = value;
                return;
            case 2: // pcl
            case 0x82:
                Register[2] = value;
                Register[0x82] = value;
                return;
            case 3: // status
            case 0x83:
                Register[3] = value;
                return;
            case 4: // fsr
            case 0x84:
                Register[4] = value;
                Register[0X84] = value;
                return;
            case 0x0A: // pclath
            case 0x8A:
                Register[0x0A] = value;
                Register[0x8A] = value;
                return;
            case 0x0B: // intcon
            case 0X8B:
                Register[0x0B] = value;
                Register[0x8B] = value;
                return;
        }

        Register[address] = value;
    }
}