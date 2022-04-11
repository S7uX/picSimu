namespace picSimu.Simulation.Instructions;

public class BSF : BitOrientedInstruction
{
    public override int Execute()
    {
        throw new NotImplementedException();
    }

    public BSF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}