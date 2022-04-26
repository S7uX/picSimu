namespace picSimu.Simulation.Instructions;

public class BTFSC : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = _pic.Memory.ReadRegister(f);
        if (!Lib.IsBitSet(val, b))
        {
            _pic.Programmcounter++; //NOP
        }

        _pic.Programmcounter++;
        return 0;
    }

    public BTFSC(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}