namespace picSimu.Simulation;

public class Memory
{
    private uint[] register = new uint[256];

    public bool BankSelect()
    {
        return Lib.IsBitSet(register[3], 5);
    }

    public uint ReadRegister(uint address)
    {
        if (!BankSelect())
        {
            // bank 0
            address = address.SetBitTo0(7);
            if (0x30 <= address || address == 7)
            {
                return 0;
            }
        }
        else
        {
            // bank 1
            address = address.SetBitTo1(7);
            if (0xD0 <= address || address == 0x87)
            {
                return 0;
            }
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                return register[0];
            case 2: // pcl
            case 0x82:
                return register[2];
            case 3: // status
            case 0x83:
                return register[3];
            case 4: // fsr
            case 0x84:
                return register[4];
            case 0x0A: // pclath
            case 0x8A:
                return register[0x0A];
            case 0x0B: // intcon
            case 0X8B:
                return register[0x0B];
        }

        return register[address];
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
                register[0] = value;
                register[0x80] = value;
                return;
            case 2: // pcl
            case 0x82:
                register[2] = value;
                register[0x82] = value;
                return;
            case 3: // status
            case 0x83:
                register[3] = value;
                return;
            case 4: // fsr
            case 0x84:
                register[4] = value;
                register[0X84] = value;
                return;
            case 0x0A: // pclath
            case 0x8A:
                register[0x0A] = value;
                register[0x8A] = value;
                return;
            case 0x0B: // intcon
            case 0X8B:
                register[0x0B] = value;
                register[0x8B] = value;
                return;
        }

        register[address] = value;
    }
}