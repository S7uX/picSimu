namespace picSimu.Simulation.Instructions;

public abstract class LiteralInstruction : Instruction
{
    public ushort k { get; set; }

    protected LiteralInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        k = Convert.ToUInt16(binaryString.Substring(6, 8), 2);
    }
}