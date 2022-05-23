namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class ADDLW : LiteralInstruction
{
    public ADDLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint Wnew = Pic.WRegister + k;
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

        uint dc = Pic.WRegister & 15; //Maskierung auf nur lowest 4 Bit
        int val2 = k & 15; //Maskierung auf nur lowest 4 Bit
        if (dc + val2 > 15)
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