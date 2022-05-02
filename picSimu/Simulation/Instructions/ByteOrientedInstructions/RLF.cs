namespace picSimu.Simulation.Instructions;

public class RLF : ByteOrientedInstruction
{
    public RLF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        string value = Convert.ToString(_pic.Memory.ReadRegister(f), 2).PadLeft(8, '0');
        if (_pic.Memory.GetCarryFlag())
        {
            value += 1;
        }
        else
        {
            value += 0;
        }

        if (value.Substring(0, 1) == "0")
        {
            _pic.Memory.SetCarryFlag(false);
        }
        else
        {
            _pic.Memory.SetCarryFlag(true);
        }
        
       
        if (d == 0)
        {
            _pic.WRegister = Convert.ToUInt16(value.Substring(1, 8), 2);
        }
        else
        {
            _pic.Memory.WriteRegister(f, Convert.ToUInt16(value.Substring(1, 8), 2));
        }

        
        _pic.IncreaseProgramCounter();
        return 0;
    }
}