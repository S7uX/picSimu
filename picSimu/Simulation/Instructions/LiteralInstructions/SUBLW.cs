namespace picSimu.Simulation.Instructions;

public class SUBLW : LiteralInstruction
{
    public SUBLW(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        uint WOld = _pic.wRegister;
        uint Wnew = WOld - k;
        if (Wnew == 0)
        {
            //ZeroFlag = 1;
        }
        else
        {
            //ZeroFlag = 0;
        }

        if (Wnew > 255)
        {
            Wnew &= 255; //Maskierung auf nur lowest 8 Bit
            Wnew = 256 - Wnew; //Magic
            //Carryflag = 1;
        }
        else
        {
            //Carryflag = 0;
        }
        if (WOld < 15 && Wnew > 15)
        {
            //CarryDigitFlag = 1;
        }
        else
        {
            //CarryDigitFlag = 0;
        }
        _pic.wRegister = Wnew;
        _pic.Programmcounter++;
        return 0;
    }
}