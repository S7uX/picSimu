namespace picSimu.Simulation.Instructions;

public abstract class ByteOrientedInstruction : Instruction
{
    public ushort f { get; set; }
    public ushort d { get; set; }

    protected ByteOrientedInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        d = Convert.ToUInt16(binaryString.Substring(6, 1), 2);
        f = Convert.ToUInt16(binaryString.Substring(7, 7), 2);
    }
}