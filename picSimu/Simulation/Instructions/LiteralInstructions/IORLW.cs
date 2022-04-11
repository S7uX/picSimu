namespace picSimu.Simulation.Instructions;

public class IORLW : LiteralInstruction
{
    public IORLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.wRegister |= k;
        if (_pic.wRegister == 0)
        {
            //Zeroflag auf 1
        }
        else
        {
            //Zeroflag auf 0
        }
        _pic.Programmcounter++;
        return 0;
    }
}