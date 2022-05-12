namespace picSimu.Simulation.Instructions;

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
        Pic.Memory.WriteRegister(2, k);

        return 0;
    }
}