namespace picSimu.Simulation.Instructions.ByteOrientedInstructions;

public class SWAPF : ByteOrientedInstruction
{
    public SWAPF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        string binaryString = Convert.ToString(Pic.Memory.ReadRegisterForInstructions(f), 2);
        binaryString = binaryString.PadLeft(8, '0');
        string lowerNipple = binaryString.Substring(4, 4);
        string upperNipple = binaryString.Substring(0, 4);
        string resultString = lowerNipple + upperNipple;
        uint result = Convert.ToUInt32(resultString, 2);

        if (d == 0)
        {
            Pic.WRegister = result;
        }
        else
        {
            Pic.Memory.WriteRegisterForInstructions(f, result);
        }

        Pic.IncreaseProgramCounter();
        return 0;
    }
}