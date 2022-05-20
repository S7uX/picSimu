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
        
        Pic.Scaler = 0; // 0 → WDT prescaler
        Pic.Memory.WriteRegister(0x01, 0x00); // 00h → WDT
        return 0;
    }
}