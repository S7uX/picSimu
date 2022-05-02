namespace picSimu.Simulation.Instructions;

public class CALL : JumpInstruction
{
    public CALL(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        _pic.IncreaseProgramCounter();
        
        _pic.Stack.push(_pic.Programmcounter + 1);
        _pic.Programmcounter = k;
        
        return 0;
    }
}