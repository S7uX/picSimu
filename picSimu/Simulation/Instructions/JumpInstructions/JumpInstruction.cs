namespace picSimu.Simulation.Instructions;

public abstract class JumpInstruction : Instruction
{
    public string k { get; set; }
    
    protected JumpInstruction(string binaryString) : base(binaryString)
    {
        k = binaryString.Substring(3, 11);
    }
}