namespace picSimu.Simulation.Instructions;

public class CLRF : ByteOrientedInstruction
{
    public CLRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.Memory.WriteRegister(f, 0);
        _pic.Memory.SetZeroFlag(true);
        _pic.Programmcounter++;
        return 0;
    }
}