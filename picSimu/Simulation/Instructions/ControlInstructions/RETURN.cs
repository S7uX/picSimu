﻿namespace picSimu.Simulation.Instructions;

public class RETURN : ControlInstruciton
{
    public RETURN(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        throw new NotImplementedException();
    }
}