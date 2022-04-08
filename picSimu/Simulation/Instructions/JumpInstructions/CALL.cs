namespace picSimu.Simulation.Instructions;

public class CALL : JumpInstruction
{
    public CALL(string binaryString) : base(binaryString)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}