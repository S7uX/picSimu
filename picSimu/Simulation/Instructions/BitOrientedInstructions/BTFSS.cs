namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BTFSS : BitOrientedInstruction
{
    public BTFSS(string binaryString, Pic pic) : base(binaryString, pic)
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
        if (val.IsBitSet(b))
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