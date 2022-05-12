namespace picSimu.Simulation.Instructions;

public class SUBLW : LiteralInstruction
{
    public SUBLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint WOld = Pic.WRegister;
        uint Wnew = WOld - k;
        if (Wnew == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (Wnew > 255)
        {
            Wnew &= 255; //Maskierung auf nur lowest 8 Bit
            Wnew = 256 - Wnew; //Magic
            Pic.Memory.SetCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetCarryFlag(false);
        }

        var val1 = WOld & 15; //Maskierung auf nur lowest 4 Bit
        var val2 = k & 15; //Maskierung auf nur lowest 4 Bit

        if (val1 - val2 <= 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            Pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetDigitCarryFlag(false);
        }

        Pic.WRegister = Wnew;
        Pic.IncreaseProgramCounter();
        return 0;
    }
}