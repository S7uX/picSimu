namespace picSimu.Simulation.Instructions;

public class BCF : BitOrientedInstruction
{
    public override int Execute()
    {
        throw new NotImplementedException();
    }

    public BCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}