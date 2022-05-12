namespace picSimu.Simulation.Instructions;

public class MOVLW : LiteralInstruction
{
    public MOVLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.WRegister = k;
        Pic.IncreaseProgramCounter();
        return 0;
    }
}