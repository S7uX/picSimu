namespace picSimu.Simulation.Instructions;

public class RLF : ByteOrientedInstruction
{
    public RLF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}