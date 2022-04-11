using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class Pic
{
    public uint wRegister = 0;
    public uint Programmcounter = 0;

    private Instruction[] _programMemory;
    public Instruction[] ProgramMemory => _programMemory;

    public CircularStack Stack;

    public Pic()
    {
        _programMemory = new Instruction[1024];
        Stack =  new CircularStack(8);
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
            Console.WriteLine("Wregister = " + wRegister);
            Console.WriteLine("PC = " + Programmcounter);
            Console.WriteLine("Wregister = " + wRegister);
            Console.WriteLine("Wregister = " + wRegister);
            _programMemory[Programmcounter].Execute();
        }
    }
}