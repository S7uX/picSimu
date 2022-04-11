namespace picSimu.Simulation.Instructions;

public class COMF : ByteOrientedInstruction
{
    public COMF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}