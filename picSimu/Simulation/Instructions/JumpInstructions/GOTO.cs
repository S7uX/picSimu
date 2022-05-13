namespace picSimu.Simulation.Instructions.JumpInstructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.IncreaseProgramCounter();
        SetProgramCounter(k);

        return 0;
    }
}