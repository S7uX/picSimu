namespace picSimu.Simulation.Instructions.LiteralInstructions;

/// <summary>
/// Opcode:
/// xx xxxx kkkk kkkk
/// </summary>
public abstract class LiteralInstruction : Instruction
{
    public ushort k { get; set; }

    protected LiteralInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        k = Convert.ToUInt16(binaryString.Substring(6, 8), 2);
    }

    protected LiteralInstruction(ushort k)
    {
        this.k = k;
    }

    public override bool Equals(object? obj)
    {
        return Lib.SameType(this, obj) && k == (obj as LiteralInstruction)?.k;
    }
}