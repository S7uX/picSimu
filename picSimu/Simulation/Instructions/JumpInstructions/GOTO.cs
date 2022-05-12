namespace picSimu.Simulation.Instructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        Pic.IncreaseProgramCounter();
        Pic.Memory.WriteRegister(2, k);

        return 0;
    }
}