using picSimu.Simulation.Instructions;
using picSimu.Simulation.Registers;

namespace picSimu.Simulation;

public class Pic
{
    public static int ProgramMemoryLength = 1024;
    public uint wRegister = 0;
    public uint Programmcounter = 0;

    private Instruction[] _programMemory;
    public Instruction[] ProgramMemory => _programMemory;
    public bool[] BreakPoints = Array.Empty<bool>();

    public readonly Memory Memory;

    public CircularStack Stack;

    public Pic()
    {
        _programMemory = new Instruction[1024];
        Stack = new CircularStack(8);
        Memory = new Memory();
    }

    public void LoadInstructionCodes(string[] hexStrings)
    {
        int i = 0;
        foreach (var hexString in hexStrings)
        {
            _programMemory[i] = InstructionDecoder.Decode(hexString, this);
            i++;
        }

        BreakPoints = new bool[_programMemory.Length];
    }

    public void Run()
    {
        //TODO
    }

    public void Step()
    {
        _programMemory[Programmcounter].Execute();
    }

    public void Stop()
    {
        //TODO
    }

    public Breakpoint GetBreakPoint(int i)
    {
        return new Breakpoint(BreakPoints, i);
    }
}
