namespace picSimu.Simulation.Instructions;

public abstract class BitOrientedInstruction : Instruction
{
    public ushort f { get; set; }
    public ushort b { get; set; }

    protected BitOrientedInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        b = Convert.ToUInt16(binaryString.Substring(4, 3), 2);
        f = Convert.ToUInt16(binaryString.Substring(7, 7), 2);
    }
}