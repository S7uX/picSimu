﻿namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class RETLW : LiteralInstruction
{
    public RETLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            Pic.ProgramCounter = Pic.Stack.Pop();
            Pic.WRegister = k;
            return 1;
        }

        CycleTwo = true;

        return 0;
    }
}