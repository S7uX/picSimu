namespace picSimu.Simulation.Instructions;

public class DECFSZ : ByteOrientedInstruction
{
    public DECFSZ(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        var val = _pic.Memory.ReadRegister(f);
        val--;
        val &= 255;

        if (d == 0)
        {
            _pic.wRegister = val;
        }
        else
        {
            _pic.Memory.WriteRegister(f, val);
        }

        if (val == 0)
        {
            _pic.IncreaseProgramCounter(); //NOP
        }
        _pic.IncreaseProgramCounter();
        return 0;
    }
}