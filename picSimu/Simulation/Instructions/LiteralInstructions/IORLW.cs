namespace picSimu.Simulation.Instructions;

public class IORLW : LiteralInstruction
{
    public IORLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.WRegister |= k;
        if (_pic.WRegister == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }
        _pic.IncreaseProgramCounter();
        return 0;
    }
}