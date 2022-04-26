namespace picSimu.Simulation.Instructions;

public class BSF : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = _pic.Memory.ReadRegister(f);

        val = val.SetBitTo1(b);

        _pic.Memory.WriteRegister(f, val);
        _pic.Programmcounter++;
        return 0;
    }

    public BSF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}