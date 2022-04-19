using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic
{
    public uint wRegister = 0;
    public uint Programmcounter = 0;

    private Instruction[] _programMemory;
    public Instruction[] ProgramMemory => _programMemory;

    public readonly Memory Memory;

    public CircularStack Stack;

    public Pic()
    {
        _programMemory = new Instruction[1024];
        Stack =  new CircularStack(8);
        Memory = new Memory();
    }

    public void Run(string[] hexStrings)
    {
        int i = 0;
        foreach (var hexString in hexStrings)
        {
            _programMemory[i] = InstructionDecoder.Decode(hexString, this);
            i++;
        }

        while (true)
        {
            _programMemory[Programmcounter].Execute();
        }
    }
}