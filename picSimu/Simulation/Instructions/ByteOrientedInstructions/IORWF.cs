namespace picSimu.Simulation.Instructions;

public class IORWF : ByteOrientedInstruction
{
    public IORWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) | _pic.WRegister;
        if (result == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }

        if (d == 0)
        {
            _pic.WRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        _pic.IncreaseProgramCounter();
        return 0;
    }
}