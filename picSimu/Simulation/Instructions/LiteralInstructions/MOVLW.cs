namespace picSimu.Simulation.Instructions;

public class MOVLW : LiteralInstruction
{
    public MOVLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.wRegister = k;
        _pic.IncreaseProgramCounter();
        return 0;
    }
}