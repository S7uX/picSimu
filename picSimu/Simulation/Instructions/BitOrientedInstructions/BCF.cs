namespace picSimu.Simulation.Instructions.BitOrientedInstructions;

public class BCF : BitOrientedInstruction
{
    public BCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint val = Pic.Memory.ReadRegisterForInstructions(f);

        val = val.SetBitTo0(b);

        Pic.Memory.WriteRegisterForInstructions(f, val);
        Pic.IncreaseProgramCounter();
        return 0;
    }
}