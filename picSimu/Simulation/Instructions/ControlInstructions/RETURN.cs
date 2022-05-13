namespace picSimu.Simulation.Instructions.ControlInstructions;

public class RETURN : ControlInstruction
{
    public RETURN(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.IncreaseProgramCounter();

        Pic.ProgramCounter = Pic.Stack.Pop();
        return 0;
    }
}