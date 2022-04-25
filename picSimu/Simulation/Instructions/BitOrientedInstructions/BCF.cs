namespace picSimu.Simulation.Instructions;

public class BCF : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = _pic.Memory.ReadRegister(f);

        val = val.SetBitTo0(b);

        _pic.Memory.WriteRegister(f, val);
        _pic.Programmcounter++;
        return 0;
    }

    public BCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}