namespace picSimu.Simulation.Instructions;

public class DECFSZ : ByteOrientedInstruction
{
    public DECFSZ(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}