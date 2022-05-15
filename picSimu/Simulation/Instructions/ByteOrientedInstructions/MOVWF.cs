namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class MOVWF : ByteOrientedInstruction
{
    public MOVWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
    
    public MOVWF(ushort f, ushort d)
    {
        this.f = f;
        this.d = d;
    }

    public override int Execute()
    {
        Pic.Memory.WriteRegisterForInstructions(f, Pic.WRegister);
        Pic.IncreaseProgramCounter();
        return 0;
    }
}