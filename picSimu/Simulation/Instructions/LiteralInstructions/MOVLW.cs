namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class MOVLW : LiteralInstruction
{
    public MOVLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public MOVLW(ushort k) : base(k)
    {
    }

    public override int Execute()
    {
        Pic.WRegister = k;
        Pic.IncreaseProgramCounter();
        return 0;
    }
}