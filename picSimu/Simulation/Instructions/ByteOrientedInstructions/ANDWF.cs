namespace picSimu.Simulation.Instructions;

public class ANDWF : ByteOrientedInstruction
{
    public ANDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
    
    public override int Execute()
    {
        throw new NotImplementedException();
    }


}