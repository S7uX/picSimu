namespace picSimu.Simulation.Instructions;

public class RETLW : LiteralInstruction
{
    public RETLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.IncreaseProgramCounter();

        Pic.Memory.WriteRegister(2, Pic.Stack.Pop());
        Pic.WRegister = k;
        return 0;
    }
}