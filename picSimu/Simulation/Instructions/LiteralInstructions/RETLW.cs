namespace picSimu.Simulation.Instructions;

public class RETLW : LiteralInstruction
{
    public RETLW(string binaryString) : base(binaryString)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}