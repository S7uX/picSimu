﻿namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class MOVWF : ByteOrientedInstruction
{
    public MOVWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.Memory.WriteRegister(f, _pic.wRegister);
        _pic.IncreaseProgramCounter();
        return 0;
    }
}