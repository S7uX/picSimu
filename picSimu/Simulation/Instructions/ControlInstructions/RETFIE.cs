namespace picSimu.Simulation.Instructions.ControlInstructions;

public class RETFIE : ControlInstruction
{
    public RETFIE(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            Pic.ProgramCounter = Pic.Stack.Pop();
            Memory.WriteRegister(0x0B, Memory.ReadRegister(0x0B).SetBitTo1(7));
            return 1;
        }

        CycleTwo = true;

        return 0;
    }
}