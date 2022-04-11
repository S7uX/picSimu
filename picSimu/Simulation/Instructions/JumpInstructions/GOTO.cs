namespace picSimu.Simulation.Instructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.Programmcounter = k;
        return 0;
    }
}