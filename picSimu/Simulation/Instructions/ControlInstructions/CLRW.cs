namespace picSimu.Simulation.Instructions;

public class CLRW : ControlInstruciton
{
    public CLRW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.wRegister = 0;
        _pic.Memory.SetZeroFlag(true);
        _pic.IncreaseProgramCounter();
        return 0;
    }
}