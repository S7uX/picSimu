namespace picSimu.Simulation.Instructions.ControlInstructions;

public abstract class ControlInstruction : Instruction
{
    protected ControlInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}