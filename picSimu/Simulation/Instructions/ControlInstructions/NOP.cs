namespace picSimu.Simulation.Instructions.ControlInstructions;

public class NOP : ControlInstruction
{
    public NOP(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        return 0;
    }
}