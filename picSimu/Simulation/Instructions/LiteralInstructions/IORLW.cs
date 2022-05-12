namespace picSimu.Simulation.Instructions;

public class IORLW : LiteralInstruction
{
    public IORLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.WRegister |= k;
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