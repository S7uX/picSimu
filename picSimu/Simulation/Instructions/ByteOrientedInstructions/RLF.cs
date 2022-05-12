namespace picSimu.Simulation.Instructions;

public class RLF : ByteOrientedInstruction
{
    public RLF(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        string value = Convert.ToString(Pic.Memory.ReadRegister(f), 2).PadLeft(8, '0');
        if (Pic.Memory.GetCarryFlag())
        {
            value += 1;
        }
        else
        {
            value += 0;
        }

        if (value.Substring(0, 1) == "0")
        {
            Pic.Memory.SetCarryFlag(false);
        }
        else
        {
            Pic.Memory.SetCarryFlag(true);
        }


        if (d == 0)
        {
            Pic.WRegister = Convert.ToUInt16(value.Substring(1, 8), 2);
        }
        else
        {
            Pic.Memory.WriteRegister(f, Convert.ToUInt16(value.Substring(1, 8), 2));
        }


        Pic.IncreaseProgramCounter();
        return 0;
    }
}