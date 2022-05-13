namespace picSimu.Simulation.Instructions;

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

        var val1 = Pic.WRegister & 15; //Maskierung auf nur lowest 4 Bit
        var val2 = Pic.Memory.ReadRegisterForInstructions(f) & 15; //Maskierung auf nur lowest 4 Bit

        if (val1 - val2 > 128 || val1 - val2 == 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            Pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetDigitCarryFlag(false);
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