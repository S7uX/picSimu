namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class ANDLW : LiteralInstruction
{
    public ANDLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.WRegister &= k;
        if (Pic.WRegister == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}