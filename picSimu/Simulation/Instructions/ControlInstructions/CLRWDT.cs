﻿namespace picSimu.Simulation.Instructions;

public class CLRWDT : ControlInstruciton
{
    public CLRWDT(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        var value = Pic.Memory.UnmaskedReadRegister(0x83);
        value.SetBitTo1(3); //1 → PD
        value.SetBitTo1(4); //1 → TO
        Pic.Memory.UnmaskedWriteRegister(0x83, value);
        Pic.Scaler = 0; //0 → WDT prescaler
        Pic.Memory.UnmaskedWriteRegister(0x01, 0x00); //00h → WDT
        return 0;
    }
}