namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class SUBWF : ByteOrientedInstruction
{
    public SUBWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = Pic.Memory.ReadRegisterForInstructions(f) - Pic.WRegister;
        if (result == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
            Pic.Memory.SetCarryFlag(false);
        }
        else
        {
            Pic.Memory.SetCarryFlag(true);
        }

        uint WLow = Pic.WRegister & 15; //Maskierung auf nur lowest 4 Bit
        uint KLow = Pic.Memory.ReadRegisterForInstructions(f) & 15; //Maskierung auf nur lowest 4 Bit

        if ((int)KLow - WLow < 0)
        {
            Pic.Memory.SetDigitCarryFlag(false);
        }
        else
        {
            Pic.Memory.SetDigitCarryFlag(true);
        }

        if (d == 0)
        {
            Pic.WRegister = result;
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, result);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}