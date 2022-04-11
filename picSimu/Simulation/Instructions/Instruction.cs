namespace picSimu.Simulation.Instructions;

public abstract class Instruction
{
    protected Pic _pic;
    protected string _opcode = "";
    public abstract int Execute();
    public Instruction(string binaryString, Pic pic)
    {
        _opcode = binaryString;
        _pic = pic;
    }
}