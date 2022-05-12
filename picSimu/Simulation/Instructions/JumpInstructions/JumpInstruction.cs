namespace picSimu.Simulation.Instructions;

public abstract class JumpInstruction : Instruction
{
    public ushort k { get; set; }

    protected uint CalculateProgramCounter(uint jumpAddressOpcode)
    {
        jumpAddressOpcode &= 0b_111_1111_1111; // mask low byte
        uint pclath = Memory.UnmaskedReadRegister(0x0A) & 0b_0001_1111;
        pclath <<= 8; // high byte
        pclath &= 0b_0001_1000; // mask PCLATH<4:3> bits 
        Console.WriteLine(pclath.ToTooltipString());
        jumpAddressOpcode |= pclath; // PCLATH register <4:0> bits <--> high byte bits PC<12:8>
        return jumpAddressOpcode;
    }

    protected JumpInstruction(string binaryString, Pic pic) : base(binaryString, pic)
    {
        k = Convert.ToUInt16(binaryString.Substring(3, 11), 2);
    }
}