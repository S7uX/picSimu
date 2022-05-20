namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class SUBLW : LiteralInstruction
{
    public SUBLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint wOld = Pic.WRegister;
        uint wnew = wOld - k;
        if (wnew == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (wnew > 255)
        {
            wnew &= 255; // mask first byte
            wnew = 256 - wnew; //Magic
            Pic.Memory.SetCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetCarryFlag(false);
        }

        uint val1 = wOld & 15; // mask lowest 4 bits
        int val2 = k & 15; // mask lowest 4 bits

        if (val1 - val2 <= 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            Pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetDigitCarryFlag(false);
        }

        Pic.WRegister = wnew;
        Pic.IncreaseProgramCounter();
        return 0;
    }
}