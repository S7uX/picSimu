namespace picSimu.Simulation.Instructions;

public class SLEEP : ControlInstruciton
{
    public SLEEP(string binaryString, Pic pic) : base(binaryString, pic)
    {
    }

    public override int Execute()
    {
        _pic.IncreaseProgramCounter();
        /*
        00h → WDT,
        0 → WDT prescaler,
        1 → TO,
        0 → PD
        */
        return 0;
    }
}