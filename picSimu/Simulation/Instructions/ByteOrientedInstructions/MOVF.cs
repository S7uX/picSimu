namespace picSimu.Simulation.Instructions;

public class MOVF : ByteOrientedInstruction
{
    public MOVF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (Pic.Memory.ReadRegister(f) == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        if (d == 0)
        {
            Pic.WRegister = Pic.Memory.ReadRegister(f);
        }
        else
        {
            Pic.Memory.WriteRegister(f, Pic.Memory.ReadRegister(f));
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}