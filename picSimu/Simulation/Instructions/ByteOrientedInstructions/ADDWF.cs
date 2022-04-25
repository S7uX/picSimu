namespace picSimu.Simulation.Instructions;

public class ADDWF : ByteOrientedInstruction
{
    public ADDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.wRegister + _pic.Memory.ReadRegister(f);
        if (result == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }

        if (result > 255)
        {
            result &= 255;
            _pic.Memory.SetCarryFlag(true);
        }
        else
        {
            _pic.Memory.SetCarryFlag(false);
        }

        if (d == 0)
        {
            if (_pic.wRegister < 15 && result > 15)
            {
                _pic.Memory.SetDigitCarryFlag(true);
            }
            else
            {
                _pic.Memory.SetDigitCarryFlag(false);
            }

            _pic.wRegister = result;
        }
        else
        {
            if (_pic.Memory.ReadRegister(f) < 15 && result > 15)
            {
                _pic.Memory.SetDigitCarryFlag(true);
            }
            else
            {
                _pic.Memory.SetDigitCarryFlag(false);
            }
            
            _pic.Memory.WriteRegister(f, result);
        }
        
        _pic.Programmcounter++;
        return 0;
    }
}