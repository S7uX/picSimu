namespace picSimu.Simulation.Instructions;

public class RETURN : ControlInstruciton
{
    public RETURN(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.Programmcounter = _pic.Stack.pop();
        return 0;
    }
}