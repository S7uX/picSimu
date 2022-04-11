namespace picSimu.Simulation.Instructions;

public class MOVF : ByteOrientedInstruction
{
    public MOVF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}