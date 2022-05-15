namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BTFSC : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegisterForInstructions(f);
        if (!Lib.IsBitSet(val, b))
        {
            Pic.IncreaseProgramCounter(); //NOP
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }

    public BTFSC(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}