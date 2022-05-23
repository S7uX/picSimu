namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class ADDWF : ByteOrientedInstruction
{
    public ADDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = Pic.WRegister + Pic.Memory.ReadRegisterForInstructions(f);
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
            result &= 255;
            Pic.Memory.SetCarryFlag(true);
        }
        else
        {
            Pic.Memory.SetCarryFlag(false);
        }

        uint dc = (Pic.WRegister & 0b_0000_1111) + (Pic.Memory.ReadRegisterForInstructions(f) & 0b_0000_1111);
        if (dc > 15)
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