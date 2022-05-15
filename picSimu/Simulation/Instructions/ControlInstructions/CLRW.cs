namespace picSimu.Simulation.Instructions.ControlInstructions;

public class CLRW : ControlInstruction
{
    public CLRW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.WRegister = 0;
        Pic.Memory.SetZeroFlag(true);
        Pic.IncreaseProgramCounter();
        return 0;
    }
}