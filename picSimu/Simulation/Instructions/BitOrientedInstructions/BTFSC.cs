namespace picSimu.Simulation.Instructions;

public class BTFSC : BitOrientedInstruction
{
    public override int Execute()
    {
        throw new NotImplementedException();
    }

    public BTFSC(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}