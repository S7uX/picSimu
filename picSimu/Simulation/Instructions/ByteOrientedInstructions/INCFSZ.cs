﻿namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class INCFSZ : ByteOrientedInstruction
{
    public INCFSZ(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint val = Pic.Memory.ReadRegisterForInstructions(f);
        val++;
        val &= 255;

        if (d == 0)
        {
            Pic.WRegister = val;
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, val);
        }

        if (val == 0)
        {
            Pic.IncreaseProgramCounter(); //NOP
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}