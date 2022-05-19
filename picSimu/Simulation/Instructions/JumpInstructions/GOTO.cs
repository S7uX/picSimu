namespace picSimu.Simulation.Instructions.JumpInstructions;

public class GOTO : JumpInstruction
{
    public GOTO(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        bool alreadyInterrupted = Memory.ReadRegister(0x0B).IsBitSet(2);
        Pic.IncreaseProgramCounter();
        if (alreadyInterrupted == false && Memory.ReadRegister(0x0B).IsBitSet(2))
        {
            return 0;
        }
        Pic.IncreaseProgramCounter();
        SetProgramCounter(k);

        return 0;
    }
}