namespace picSimu.Simulation.Instructions;

public abstract class Instruction : Object
{
    protected readonly Pic Pic;
    protected readonly Memory Memory;
    public readonly string Opcode = "";
    public bool CycleTwo = false;
    
    public abstract int Execute();

    public Instruction(string binaryString, Pic pic)
    {
        Opcode = binaryString;
        Pic = pic;
        Memory = pic.Memory;
    }

    protected Instruction()
    {
    }
}