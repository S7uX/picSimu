namespace picSimu.Simulation.Instructions;

public class IORWF : ByteOrientedInstruction
{
    public IORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}