namespace picSimu.Simulation.Instructions;

public class SUBWF : ByteOrientedInstruction
{
    public SUBWF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint result = _pic.Memory.ReadRegister(f) - _pic.wRegister;
        if (result == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }

        if (result > 255)
        {
            result &= 255; //Maskierung auf nur lowest 8 Bit
            _pic.Memory.SetCarryFlag(false);
        }
        else
        {
            _pic.Memory.SetCarryFlag(true);
        }

        var val1 = _pic.wRegister & 15; //Maskierung auf nur lowest 4 Bit
        var val2 = _pic.Memory.ReadRegister(f) & 15; //Maskierung auf nur lowest 4 Bit

        if (val1 - val2 > 128 || val1 - val2 == 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            _pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            _pic.Memory.SetDigitCarryFlag(false);
        }
        
        if (d == 0)
        {
            _pic.wRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        _pic.Programmcounter++;
        return 0;
    }
}