using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic
{
    private uint wRegister = 0;

    private Instruction[] _programMemory;
    public Instruction[] ProgramMemory => _programMemory;

    public Pic(Instruction[] programMemory)
    {
        _programMemory = new Instruction[1024];
    }
}