namespace picSimu.Simulation.Instructions;

public class INCFSZ : ByteOrientedInstruction
{
    public INCFSZ(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}