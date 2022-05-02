namespace picSimu.Simulation.Instructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        _pic.IncreaseProgramCounter();
        _pic.Memory.WriteRegister(2, k);
        
        return 0;
    }
}