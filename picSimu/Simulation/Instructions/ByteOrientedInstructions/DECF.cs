namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class DECF : ByteOrientedInstruction
{
    public DECF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = Pic.Memory.ReadRegisterForInstructions(f) - 1;
        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
        }

        if (d == 0)
        {
            Pic.WRegister = result;
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, result);
        }

        if (result == 0)
        {
            Pic.Memory.SetZeroFlag(true);
        }
        else
        {
            Pic.Memory.SetZeroFlag(false);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}