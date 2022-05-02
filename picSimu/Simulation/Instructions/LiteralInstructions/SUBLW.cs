namespace picSimu.Simulation.Instructions;

public class SUBLW : LiteralInstruction
{
    public SUBLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint WOld = _pic.WRegister;
        uint Wnew = WOld - k;
        if (Wnew == 0)
        {
            _pic.Memory.SetZeroFlag(true);
        }
        else
        {
            _pic.Memory.SetZeroFlag(false);
        }

        if (Wnew > 255)
        {
            Wnew &= 255; //Maskierung auf nur lowest 8 Bit
            Wnew = 256 - Wnew; //Magic
            _pic.Memory.SetCarryFlag(true);
        }
        else
        {
            _pic.Memory.SetCarryFlag(false);
        }

        var val1 = WOld & 15; //Maskierung auf nur lowest 4 Bit
        var val2 = k & 15; //Maskierung auf nur lowest 4 Bit

        if (val1 - val2 <= 0) //inklusive 0 weil 2er komplement? also vielleicht :D
        {
            _pic.Memory.SetDigitCarryFlag(true);
        }
        else
        {
            _pic.Memory.SetDigitCarryFlag(false);
        }
        _pic.WRegister = Wnew;
        _pic.IncreaseProgramCounter();
        return 0;
    }
}