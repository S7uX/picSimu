namespace picSimu.Simulation.Instructions;

public abstract class JumpInstruction : Instruction
{
    public ushort k { get; set; }

    protected JumpInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        k = Convert.ToUInt16(binaryString.Substring(3, 11), 2);
    }
}