namespace picSimu.Simulation.Instructions;

public class RETLW : LiteralInstruction
{
    public RETLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        _pic.IncreaseProgramCounter();
        
        _pic.Programmcounter = _pic.Stack.pop();
        _pic.wRegister = k;
        return 0;
    }
}