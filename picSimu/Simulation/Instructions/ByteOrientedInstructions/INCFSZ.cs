namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class INCFSZ : ByteOrientedInstruction
{
    /// <summary>
    /// Increment f, Skip if 0
    /// </summary>
    public INCFSZ(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            Pic.IncreaseProgramCounter(); // NOP
            Pic.IncreaseProgramCounter();
            return 1;
        }

        uint val = Pic.Memory.ReadRegisterForInstructions(f);
        val++;
        val &= 255;

        if (d == 0)
        {
            Pic.WRegister = val;
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, val);
        }

        if (val == 0)
        {
            CycleTwo = true;
        }
        else
        {
            Pic.IncreaseProgramCounter();
        }

        return 0;
    }
}