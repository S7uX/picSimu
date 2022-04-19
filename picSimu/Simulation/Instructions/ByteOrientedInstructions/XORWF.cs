namespace picSimu.Simulation.Instructions;

public class XORWF : ByteOrientedInstruction
{
    public XORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.wRegister ^ _pic.Memory.ReadRegister(f);

        if (d == 0)
        {
            _pic.wRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        if (result == 0)
        {
            //Set Zeroflag
        }
        else
        {
            //Set Zeroflag
        }
        _pic.Programmcounter++;
        return 0;
    }
}