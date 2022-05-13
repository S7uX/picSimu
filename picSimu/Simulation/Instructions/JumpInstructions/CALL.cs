namespace picSimu.Simulation.Instructions.JumpInstructions;

public class CALL : JumpInstruction
{
    public CALL(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.Stack.Push(Pic.ProgramCounter);
        Pic.IncreaseProgramCounter();
        SetProgramCounter(k);

        return 0;
    }
}