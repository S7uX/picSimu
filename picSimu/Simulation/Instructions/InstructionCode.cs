namespace picSimu.Simulation.Instructions;

public class InstructionCode
{
    public string? Opcode { get; set; }
    public string? ProgramCounter { get; set; }
    public int RowNumber { get; set; } = -1;
}