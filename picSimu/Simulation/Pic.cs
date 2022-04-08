using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic
{
    private uint wRegister = 0;

    private Instruction[] _programMemory;

    // status register
    public bool ZeroFlag;
    public bool CarryFlag;
    public bool DigitcarryFlag;
    public bool IrpFlag;
    public bool Rp1Flag;
    public bool Rp0Flag;
    public bool ToFlag;
    public bool PdFlag;

    public Pic(Instruction[] programMemory)
    {
        _programMemory = programMemory;
        
        wRegister = wRegister;
        
        IrpFlag = false;
        Rp1Flag = false;
        Rp0Flag = false;
        ToFlag = true;
        PdFlag = true;
        ZeroFlag = true;
        CarryFlag = true;
        DigitcarryFlag = true;
    }
}