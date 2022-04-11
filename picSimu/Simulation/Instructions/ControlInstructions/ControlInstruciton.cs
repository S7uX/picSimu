namespace picSimu.Simulation.Instructions;

public abstract class ControlInstruciton : Instruction
{
    protected ControlInstruciton(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}