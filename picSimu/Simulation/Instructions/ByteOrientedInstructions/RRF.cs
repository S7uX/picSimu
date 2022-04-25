namespace picSimu.Simulation.Instructions;

public class RRF : ByteOrientedInstruction
{
    public RRF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        string value = "";
        if (_pic.Memory.GetCarryFlag())
        {
            value += 1;
        }
        else
        {
            value += 0;
        }
        value +=  Convert.ToString(_pic.Memory.ReadRegister(f), 2).PadLeft(8, '0');
        
        if (value.Substring(8, 1) == "0")
        {
            _pic.Memory.SetCarryFlag(false);
        }
        else
        {
            _pic.Memory.SetCarryFlag(true);
        }
        
        if (d == 0)
        {
            _pic.wRegister = Convert.ToUInt16(value.Substring(0, 8), 2);
        }
        else
        {
            _pic.Memory.WriteRegister(f, Convert.ToUInt16(value.Substring(0, 8), 2));
        }

        _pic.Programmcounter++;
        return 0;
    }
}