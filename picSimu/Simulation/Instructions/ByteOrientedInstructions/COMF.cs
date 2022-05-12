namespace picSimu.Simulation.Instructions;

public class COMF : ByteOrientedInstruction
{
    public COMF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = ~Pic.Memory.ReadRegister(f);
        result &= 255;
        if (d == 0)
        {
            Pic.WRegister = result;
        }
        else
        {
            Pic.Memory.WriteRegister(f, result);
        }

        if (result == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}