namespace picSimu.Simulation.Instructions;

public abstract class Instruction
{
    protected readonly Pic Pic;
    protected readonly Memory Memory;
    protected string _opcode = "";
    public abstract int Execute();

    public Instruction(string binaryString, Pic pic)
    {
        _opcode = binaryString;
        Pic = pic;
        Memory = pic.Memory;
    }
}