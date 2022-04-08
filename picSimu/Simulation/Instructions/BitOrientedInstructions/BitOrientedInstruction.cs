namespace picSimu.Simulation.Instructions;

public abstract class BitOrientedInstruction : Instruction
{
    public string f { get; set; }
    public string b { get; set; }

    protected BitOrientedInstruction(string binaryString) : base(binaryString)
    {
        b = binaryString.Substring(4, 3);
        f = binaryString.Substring(7, 7);
    }
}