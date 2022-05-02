namespace picSimu.Simulation.Instructions;

public class CALL : JumpInstruction
{
    public CALL(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        _pic.IncreaseProgramCounter();
        
        _pic.Stack.push(_pic.Memory.ReadRegister(2) + 1);
        _pic.Memory.WriteRegister(2, k);
        
        return 0;
    }
}