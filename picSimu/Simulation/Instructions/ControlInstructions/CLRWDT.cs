namespace picSimu.Simulation.Instructions.ControlInstructions;

public class CLRWDT : ControlInstruction
{
    public CLRWDT(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        uint value = Pic.Memory.ReadRegister(0x83);
        value.SetBitTo1(3); // 1 → PD
        value.SetBitTo1(4); // 1 → TO
        Pic.Memory.WriteRegister(0x83, value);

        if (Memory.ReadRegister(0x81).IsBitSet(3))
        {
            Pic.ResetScaler();
        } // OPTION<3> prescaler assgined to WDT?
        Pic.Memory.WriteRegister(0x01, 0x00); // 00h → WDT
        Pic.WatchdogCycles = 0;
        return 0;
    }
}