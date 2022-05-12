namespace picSimu.Simulation.Instructions;

public class RETURN : ControlInstruciton
{
    public RETURN(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.IncreaseProgramCounter();

        Pic.Memory.WriteRegister(2, Pic.Stack.Pop());
        return 0;
    }
}