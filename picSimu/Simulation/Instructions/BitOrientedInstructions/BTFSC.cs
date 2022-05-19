namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BTFSC : BitOrientedInstruction
{
    public BTFSC(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint val = Pic.Memory.ReadRegisterForInstructions(f);
        if (!val.IsBitSet(b))
        {
            Pic.IncreaseProgramCounter(); // NOP
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}