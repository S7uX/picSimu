namespace picSimu.Simulation.Instructions;

public class MOVF : ByteOrientedInstruction
{
    public MOVF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (d == 0)
        {
            _pic.wRegister = _pic.Memory.ReadRegister(f);
            if (_pic.wRegister == 0)
            {
                //Set Zero-Flag
            }
        }
        else
        {
            _pic.Memory.WriteRegister(f, _pic.Memory.ReadRegister(f));
            if (_pic.Memory.ReadRegister(f) == 0)
            {
                //Set Zero-Flag
            }
        }
        
        _pic.Programmcounter++;
        return 0;
    }
}