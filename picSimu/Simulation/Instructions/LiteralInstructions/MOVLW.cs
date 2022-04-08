namespace picSimu.Simulation.Instructions;

public class MOVLW : LiteralInstruction
{
    public MOVLW(string binaryString) : base(binaryString)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}