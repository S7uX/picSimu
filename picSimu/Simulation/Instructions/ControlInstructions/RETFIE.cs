namespace picSimu.Simulation.Instructions;

public class RETFIE : ControlInstruciton
{
    public RETFIE(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}