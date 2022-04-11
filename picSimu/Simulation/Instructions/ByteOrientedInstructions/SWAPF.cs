namespace picSimu.Simulation.Instructions;

public class SWAPF : ByteOrientedInstruction
{
    public SWAPF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}