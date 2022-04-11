namespace picSimu.Simulation.Instructions;

public class SLEEP : ControlInstruciton
{
    public SLEEP(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}