namespace picSimu.Simulation.Instructions;

public abstract class Instruction
{
    private string _opcode = "";
    public abstract int Execute();
    public Instruction(string binaryString)
    {
        _opcode = binaryString;
    }
}