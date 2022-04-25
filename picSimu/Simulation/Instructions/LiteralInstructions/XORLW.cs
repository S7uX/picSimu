namespace picSimu.Simulation.Instructions;

public class XORLW : LiteralInstruction
{
    public XORLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.wRegister ^= k;
        if (_pic.wRegister == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }
        _pic.Programmcounter++;
        return 0;
    }
}