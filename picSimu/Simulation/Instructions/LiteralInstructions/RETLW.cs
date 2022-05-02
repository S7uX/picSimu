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

        _pic.Memory.WriteRegister(2, _pic.Stack.pop());
        _pic.WRegister = k;
        return 0;
    }
}