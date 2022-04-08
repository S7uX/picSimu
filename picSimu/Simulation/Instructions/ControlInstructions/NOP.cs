namespace picSimu.Simulation.Instructions;

public class NOP : ControlInstruciton
{
    public NOP(string binaryString) : base(binaryString)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}