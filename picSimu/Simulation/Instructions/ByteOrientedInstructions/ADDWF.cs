namespace picSimu.Simulation.Instructions;

public class ADDWF : ByteOrientedInstruction
{
    public ADDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = Pic.WRegister + Pic.Memory.ReadRegister(f);
        if (result == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (result > 255)
        {
            result &= 255;
            Pic.Memory.SetCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetCarryFlag(false);
        }

        if (d == 0)
        {
            if (Pic.WRegister < 15 && result > 15)
            {
                Pic.Memory.SetDigitCarryFlag(true);
            }
            else
            {
                Pic.Memory.SetDigitCarryFlag(false);
            }

            Pic.WRegister = result;
        }
        else
        {
            if (Pic.Memory.ReadRegister(f) < 15 && result > 15)
            {
                Pic.Memory.SetDigitCarryFlag(true);
            }
            else
            {
                Pic.Memory.SetDigitCarryFlag(false);
            }

            Pic.Memory.WriteRegister(f, result);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}