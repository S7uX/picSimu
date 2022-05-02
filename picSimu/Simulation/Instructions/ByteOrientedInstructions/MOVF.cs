namespace picSimu.Simulation.Instructions;

public class MOVF : ByteOrientedInstruction
{
    public MOVF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        if (_pic.Memory.ReadRegister(f) == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }
        
        if (d == 0)
        {
            _pic.WRegister = _pic.Memory.ReadRegister(f);
        }
        else
        {
            _pic.Memory.WriteRegister(f, _pic.Memory.ReadRegister(f));
        }
        
        _pic.IncreaseProgramCounter();
        return 0;
    }
}