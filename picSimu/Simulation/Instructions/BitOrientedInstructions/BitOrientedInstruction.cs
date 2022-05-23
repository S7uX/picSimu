namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

/// <summary>
/// Opcode:
/// 01 xxbb bfff ffff
/// </summary>
public abstract class BitOrientedInstruction : Instruction
{
    protected ushort f { get; set; }
    protected ushort b { get; set; }

    protected BitOrientedInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        b = Convert.ToUInt16(binaryString.Substring(4, 3), 2);
        f = Convert.ToUInt16(binaryString.Substring(7, 7), 2);
    }

    protected BitOrientedInstruction(ushort f, ushort b)
    {
        this.f = f;
        this.b = b;
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && Lib.SameType(this, obj))
        {
            var boi = obj as BitOrientedInstruction;
            return f == boi?.f && b == boi.b;
        }

        return false;
    }
}