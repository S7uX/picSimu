namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class XORWF : ByteOrientedInstruction
{
    public XORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = Pic.WRegister ^ Pic.Memory.ReadRegisterForInstructions(f);

        if (result == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
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