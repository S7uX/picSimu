namespace picSimu.Simulation.Instructions;

public class InstructionCode
{
    public uint Opcode { get; set; }
    public int ProgramCounter { get; set; }
    public int RowNumber { get; set; } = -1;
}