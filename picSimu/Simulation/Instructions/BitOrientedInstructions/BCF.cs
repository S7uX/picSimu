namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BCF : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegisterForInstructions(f);

        val = val.SetBitTo0(b);

        Pic.Memory.WriteRegisterForInstructions(f, val);
        Pic.IncreaseProgramCounter();
        return 0;
    }

    public BCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}