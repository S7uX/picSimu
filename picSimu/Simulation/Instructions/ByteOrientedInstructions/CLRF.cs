namespace picSimu.Simulation.Instructions;

public class CLRF : ByteOrientedInstruction
{
    public CLRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.Memory.WriteRegisterForInstructions(f, 0);
        Pic.Memory.SetZeroFlag(true);
        Pic.IncreaseProgramCounter();
        return 0;
    }
}