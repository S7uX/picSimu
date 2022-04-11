namespace picSimu.Simulation.Instructions;

public class SUBWF : ByteOrientedInstruction
{
    public SUBWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}