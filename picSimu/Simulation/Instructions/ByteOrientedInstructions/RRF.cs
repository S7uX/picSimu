﻿namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class RRF : ByteOrientedInstruction
{
    public RRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        string value = "";
        if (Pic.Memory.GetCarryFlag())
        {
            value += 1;
        }
        else
        {
            value += 0;
        }

        value += Convert.ToString(Pic.Memory.ReadRegisterForInstructions(f), 2).PadLeft(8, '0');

        if (value.Substring(8, 1) == "0")
        {
            Pic.Memory.SetCarryFlag(false);
        }
        else
        {
            Pic.Memory.SetCarryFlag(true);
        }

        if (d == 0)
        {
            Pic.WRegister = Convert.ToUInt16(value.Substring(0, 8), 2);
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, Convert.ToUInt16(value.Substring(0, 8), 2));
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}