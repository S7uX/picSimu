using picSimu.Simulation.Instructions.ControlInstructions;

namespace picSimu.Simulation.Instructions;

public class SLEEP : ControlInstruction
{
    public SLEEP(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        Pic.IncreaseProgramCounter();
        var value = Pic.Memory.ReadRegister(0x83);
        value.SetBitTo0(3); //0 → PD
        value.SetBitTo1(4); //1 → TO
        Pic.Memory.WriteRegister(0x83, value);
        Pic.Scaler = 0; //0 → WDT prescaler
        Pic.Memory.WriteRegister(0x01, 0x00); //00h → WDT
        return 0;
    }
}