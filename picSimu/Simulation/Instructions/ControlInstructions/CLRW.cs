﻿namespace picSimu.Simulation.Instructions;

public class CLRW : ControlInstruciton
{
    public CLRW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}