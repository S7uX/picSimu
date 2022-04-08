namespace picSimu.Simulation.Instructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString) : base(binaryString)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}