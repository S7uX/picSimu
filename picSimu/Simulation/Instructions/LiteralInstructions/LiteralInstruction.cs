namespace picSimu.Simulation.Instructions;

public abstract class LiteralInstruction : Instruction
{
    public string k { get; set; }

    protected LiteralInstruction(string binaryString) : base(binaryString)
    {
        k = binaryString.Substring(6, 8);
    }
}