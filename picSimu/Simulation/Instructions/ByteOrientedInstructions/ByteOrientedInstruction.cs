namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

/// <summary>
/// Opcode:
/// 00 0000 dfff ffff
/// </summary>
public abstract class ByteOrientedInstruction : Instruction
{
    public ushort f { get; set; }
    public ushort d { get; set; }

    protected ByteOrientedInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        d = Convert.ToUInt16(binaryString.Substring(6, 1), 2);
        f = Convert.ToUInt16(binaryString.Substring(7, 7), 2);
    }

    protected ByteOrientedInstruction()
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && Lib.SameType(this, obj))
        {
            var boi = obj as ByteOrientedInstruction;
            return f == boi?.f && d == boi.d;
        }

        return false;
    }
}