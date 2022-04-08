namespace picSimu.Simulation.Instructions;

public abstract class ByteOrientedInstruction : Instruction
{
    public string f { get; set; }
    public string d { get; set; }

    protected ByteOrientedInstruction(string binaryString) : base(binaryString)
    {
        d = binaryString.Substring(6, 1);
        f = binaryString.Substring(7, 7);
    }
}