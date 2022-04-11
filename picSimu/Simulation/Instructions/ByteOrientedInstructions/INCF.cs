namespace picSimu.Simulation.Instructions;

public class INCF : ByteOrientedInstruction
{
    public INCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}