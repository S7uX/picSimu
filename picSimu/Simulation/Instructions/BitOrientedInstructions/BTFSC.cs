namespace picSimu.Simulation.Instructions;

public class BTFSC : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = _pic.Memory.ReadRegister(f);
        if (!Lib.IsBitSet(val, b))
        {
            _pic.IncreaseProgramCounter(); //NOP
        }

        _pic.IncreaseProgramCounter();
        return 0;
    }

    public BTFSC(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}