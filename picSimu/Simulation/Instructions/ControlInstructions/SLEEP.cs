namespace picSimu.Simulation.Instructions.ControlInstructions;

public class SLEEP : ControlInstruction
{
    public SLEEP(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint value = Pic.Memory.ReadRegister(0x83); // STATUS
        value = value.SetBitTo0(3); // 0 → PD
        value = value.SetBitTo1(4); // 1 → TO
        Pic.IsSleeping = true;
        Pic.Memory.WriteRegister(0x83, value);
        Pic.ResetScaler();
        Pic.Memory.WriteRegister(0x01, 0x00); // 00h → WDT
        return 0;
    }
}