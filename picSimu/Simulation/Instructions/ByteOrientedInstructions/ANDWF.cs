namespace picSimu.Simulation.Instructions;

public class ANDWF : ByteOrientedInstruction
{
    public ANDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
    
    public override int Execute()
    {
        uint result = _pic.wRegister & _pic.Memory.ReadRegister(f);
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