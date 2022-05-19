namespace picSimu.Simulation.Instructions.JumpInstructions;

public abstract class JumpInstruction : Instruction
{
    public ushort k { get; set; }

    protected void SetProgramCounter(uint jumpAddressOpcode)
    {
        jumpAddressOpcode &= 0b_111_1111_1111; // mask 11 bit from opcode 
        uint pclath = Memory.ReadRegister(0x0A) & 0b_0001_1000; // use two PCLATH bits <4:3>
        pclath <<= 8; // high byte
        jumpAddressOpcode |= pclath;
        Pic.ProgramCounter = jumpAddressOpcode; // PCLATH register <4:0> bits <--> high byte bits PC<12:8>
    }

    protected JumpInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        k = Convert.ToUInt16(binaryString.Substring(3, 11), 2);
    }
}