﻿namespace picSimu.Simulation.Instructions.LiteralInstructions;

public class SUBLW : LiteralInstruction
{
    public SUBLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint Wnew = k - Pic.WRegister;
        if (Wnew == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (Wnew > 255)
        {
            Wnew &= 255; // Maskierung auf nur lowest 8 Bit
            Wnew = 256 - Wnew; // Overflow beheben
            Pic.Memory.SetCarryFlag(false);
        }
        else
        {
            Pic.Memory.SetCarryFlag(true);
        }

        uint Wlow = Pic.WRegister & 15; //Maskierung auf nur lowest 4 Bit
        int Klow = k & 15; //Maskierung auf nur lowest 4 Bit

        if (Klow - Wlow <= 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            Pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetDigitCarryFlag(false);
        }

        Pic.WRegister = Wnew;
        Pic.IncreaseProgramCounter();
        return 0;
    }
}