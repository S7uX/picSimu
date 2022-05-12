namespace picSimu.Simulation.Instructions;

public class BTFSS : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegister(f);
        if (Lib.IsBitSet(val, b))
        {
            Pic.IncreaseProgramCounter(); //NOP
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }

    public BTFSS(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}