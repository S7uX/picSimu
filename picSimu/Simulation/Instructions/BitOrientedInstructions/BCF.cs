namespace picSimu.Simulation.Instructions;

public class BCF : BitOrientedInstruction
{
    public override int Execute()
    {
        var val = Pic.Memory.ReadRegister(f);

        val = val.SetBitTo0(b);

        Pic.Memory.WriteRegister(f, val);
        Pic.IncreaseProgramCounter();
        return 0;
    }

    public BCF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
}