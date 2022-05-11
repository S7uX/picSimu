namespace picSimu.Simulation.Instructions;

public class CLRWDT : ControlInstruciton
{
    public CLRWDT(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        var value = _pic.Memory.UnmaskedReadRegister(0x83);
        value.SetBitTo1(3); //1 → PD
        value.SetBitTo1(4); //1 → TO
        _pic.Memory.UnmaskedWriteRegister(0x83, value);
        _pic.Scaler = 0; //0 → WDT prescaler
        _pic.Memory.UnmaskedWriteRegister(0x01, 0x00); //00h → WDT
        return 0;
    }
}