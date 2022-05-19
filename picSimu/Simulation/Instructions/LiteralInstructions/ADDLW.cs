namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class ADDLW : LiteralInstruction
{
    public ADDLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint WOld = Pic.WRegister;
        uint Wnew = WOld + k;
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
            Pic.Memory.SetCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetCarryFlag(false);
        }

        uint val1 = WOld & 15; //Maskierung auf nur lowest 4 Bit
        int val2 = k & 15; //Maskierung auf nur lowest 4 Bit
        if (val1 + val2 > 15)
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