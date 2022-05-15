namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class MOVF : ByteOrientedInstruction
{
    public MOVF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (Pic.Memory.ReadRegisterForInstructions(f) == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (d == 0)
        {
            Pic.WRegister = Pic.Memory.ReadRegisterForInstructions(f);
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, Pic.Memory.ReadRegisterForInstructions(f));
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}