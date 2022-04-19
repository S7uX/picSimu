﻿namespace picSimu.Simulation.Instructions;

public class INCF : ByteOrientedInstruction
{
    public INCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) + 1;
        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
        }
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
            //set Zero-Flag 
        }
        _pic.Programmcounter++;
        return 0;
    }
}