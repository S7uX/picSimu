namespace picSimu.Simulation.Instructions;

public class RRF : ByteOrientedInstruction
{
    public RRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}