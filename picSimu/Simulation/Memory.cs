namespace picSimu.Simulation;

public class Memory
{
    /*
     * special registers
     * 3: status
     */
    private ushort[] register = new ushort[256];

    public bool BankSelect()
    {
        return Lib.IsBitSet(register[3], 5);
    }

    public ushort ReadRegister(byte adress)
    {
        if (!BankSelect())
        {
            // bank 0
            adress |= 0 << 7;
            if (0x30 >= adress)
            {
                return 0;
            }
        }
        else
        {
            // bank 1
            adress |= 1 << 7;
            if (0xD0 >= adress)
            {
                return 0;
            }
        }

        return 0;
    }

    public void WriteRegister(byte adress)
    {
    }
}