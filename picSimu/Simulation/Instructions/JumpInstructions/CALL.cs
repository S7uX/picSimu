namespace picSimu.Simulation.Instructions.JumpInstructions;

public class CALL : JumpInstruction
{
    public CALL(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            SetProgramCounter(k);
            return 1;
        }

        CycleTwo = true;
        Pic.Stack.Push(Pic.ProgramCounter + 1);

        return 0;
    }
}