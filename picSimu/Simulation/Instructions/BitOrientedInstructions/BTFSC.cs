namespace picSimu.Simulation.Instructions;

public class BTFSC : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegister(f);
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