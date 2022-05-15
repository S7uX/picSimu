namespace picSimu.Simulation.Instructions.ControlInstructions;

public class RETFIE : ControlInstruction
{
    public RETFIE(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}