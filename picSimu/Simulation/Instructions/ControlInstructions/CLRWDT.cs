namespace picSimu.Simulation.Instructions;

public class CLRWDT : ControlInstruciton
{
    public CLRWDT(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}