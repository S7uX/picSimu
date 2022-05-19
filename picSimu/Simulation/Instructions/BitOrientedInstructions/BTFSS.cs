namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BTFSS : BitOrientedInstruction
{
    public BTFSS(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        var val = Pic.Memory.ReadRegisterForInstructions(f);
        if (val.IsBitSet(b))
        {
            Pic.IncreaseProgramCounter(); //NOP
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}