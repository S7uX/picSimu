namespace picSimu.Simulation.Instructions;

public class COMF : ByteOrientedInstruction
{
    public COMF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = ~_pic.Memory.ReadRegister(f);
        result &= 255;
        if (d == 0)
        {
            _pic.WRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        if (result == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }
        _pic.IncreaseProgramCounter();
        return 0;
    }
}