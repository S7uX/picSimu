namespace picSimu.Simulation.Instructions;

public class XORWF : ByteOrientedInstruction
{
    public XORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}