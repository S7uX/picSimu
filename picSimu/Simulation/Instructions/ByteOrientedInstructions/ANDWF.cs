namespace picSimu.Simulation.Instructions;

public class ANDWF : ByteOrientedInstruction
{
    public ANDWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }
    
    public override int Execute()
    {
        uint result = _pic.wRegister & _pic.Memory.ReadRegister(f);
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
            _pic.wRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }
        
        _pic.IncreaseProgramCounter();
        return 0;
    }


}