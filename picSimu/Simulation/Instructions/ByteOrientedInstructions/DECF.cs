namespace picSimu.Simulation.Instructions;

public class DECF : ByteOrientedInstruction
{
    public DECF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) - 1;
        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
        }
        if (d == 0)
        {
            _pic.wRegister = result;
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