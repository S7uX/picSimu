namespace picSimu.Simulation.Instructions;

public class RETLW : LiteralInstruction
{
    public RETLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}