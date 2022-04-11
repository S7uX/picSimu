namespace picSimu.Simulation.Instructions;

public class CLRF : ByteOrientedInstruction
{
    public CLRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}