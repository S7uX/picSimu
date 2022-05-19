namespace picSimu.Simulation.Instructions.JumpInstructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (CycleTwo)
        {
            SetProgramCounter(k);
            return 1;
        }

        CycleTwo = true;

        // bool alreadyInterrupted = Memory.ReadRegister(0x0B).IsBitSet(2);
        // if (alreadyInterrupted == false && Memory.ReadRegister(0x0B).IsBitSet(2))
        // {
        //     return 0;
        // }

        return 0;
    }
}