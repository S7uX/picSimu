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
            _pic.wRegister = result;
        }
        else
        {
            _pic.Memory.WriteRegister(f, result);
        }

        if (result == 0)
        {
            //Set Zero-Flag
        }
        _pic.Programmcounter++;
        return 0;
    }
}