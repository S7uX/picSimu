namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class DECFSZ : ByteOrientedInstruction
{
    public DECFSZ(string binaryString, Pic pic) : base(binaryString, pic)
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
        val--;
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