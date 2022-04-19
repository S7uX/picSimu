namespace picSimu.Simulation.Instructions;

public class SUBWF : ByteOrientedInstruction
{
    public SUBWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) - _pic.wRegister;
        if (result == 0)
        {
            //ZeroFlag = 1;
        }
        else
        {
            //ZeroFlag = 0;
        }

        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
            //Carryflag = 1;
        }
        else
        {
            //Carryflag = 0;
        }

        if (d == 0)
        {
            if (_pic.wRegister < 15 && result > 15)
            {
                //CarryDigitFlag = 1;
            }
            else
            {
                //CarryDigitFlag = 0;
            }

            _pic.wRegister = result;
        }
        else
        {
            if (_pic.Memory.ReadRegister(f) < 15 && result > 15)
            {
                //CarryDigitFlag = 1;
            }
            else
            {
                //CarryDigitFlag = 0;
            }

            _pic.Memory.WriteRegister(f, result);
        }

        _pic.Programmcounter++;
        return 0;
    }
}