namespace picSimu.Simulation.Instructions.ControlInstructions;

public class RETURN : ControlInstruction
{
    public RETURN(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            Pic.ProgramCounter = Pic.Stack.Pop();
            return 1;
        }

        CycleTwo = true;

        return 0;
    }
}