namespace picSimu.Simulation.Instructions;

public class DECF : ByteOrientedInstruction
{
    public DECF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}