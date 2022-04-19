namespace picSimu.Simulation.Instructions;

public class IORWF : ByteOrientedInstruction
{
    public IORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) | _pic.wRegister;
        if (result == 0)
        {
            //Zeroflag auf 1
        }
        else
        {
            //Zeroflag auf 0
        }

        if (d == 0)
        {
            _pic.wRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        _pic.Programmcounter++;
        return 0;
    }
}