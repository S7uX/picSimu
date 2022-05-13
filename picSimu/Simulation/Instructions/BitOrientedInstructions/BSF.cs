namespace picSimu.Simulation.Instructions;

public class BSF : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegisterForInstructions(f);

        val = val.SetBitTo1(b);

        Pic.Memory.WriteRegisterForInstructions(f, val);
        Pic.IncreaseProgramCounter();
        return 0;
    }

    public BSF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}