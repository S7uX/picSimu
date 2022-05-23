using picSimu.Simulation.Instructions;
using picSimu.Simulation.Instructions.BitOrientedInstructions;
using picSimu.Simulation.Instructions.ByteOrientedInstructions;
using picSimu.Simulation.Instructions.ControlInstructions;
using picSimu.Simulation.Instructions.JumpInstructions;
using picSimu.Simulation.Instructions.LiteralInstructions;

namespace picSimu.Simulation;

public static class InstructionDecoder
{
    public static Instruction Decode(string instructionHexString, Pic pic)
    {
        string binaryString = string.Join(string.Empty,
            instructionHexString.Select(c => Convert.ToString(Convert.ToInt32
                (c.ToString(), 16), 2).PadLeft(4, '0'))
        );

        binaryString = binaryString.Substring(2, 14);

        if (binaryString.StartsWith("000111"))
            return new ADDWF(binaryString, pic);
        if (binaryString.StartsWith("000101"))
            return new ANDWF(binaryString, pic);
        if (binaryString.StartsWith("0000011"))
            return new CLRF(binaryString, pic);
        if (binaryString.StartsWith("0000010"))
            return new CLRW(binaryString, pic);
        if (binaryString.StartsWith("001001"))
            return new COMF(binaryString, pic);
        if (binaryString.StartsWith("000011"))
            return new DECF(binaryString, pic);
        if (binaryString.StartsWith("001011"))
            return new DECFSZ(binaryString, pic);
        if (binaryString.StartsWith("001010"))
            return new INCF(binaryString, pic);
        if (binaryString.StartsWith("001111"))
            return new INCFSZ(binaryString, pic);
        if (binaryString.StartsWith("000100"))
            return new IORWF(binaryString, pic);
        if (binaryString.StartsWith("001000"))
            return new MOVF(binaryString, pic);
        if (binaryString.StartsWith("0000001"))
            return new MOVWF(binaryString, pic);
        if (binaryString.StartsWith("0000000") && binaryString.EndsWith("00000"))
            return new NOP(binaryString, pic);
        if (binaryString.StartsWith("001101"))
            return new RLF(binaryString, pic);
        if (binaryString.StartsWith("001100"))
            return new RRF(binaryString, pic);
        if (binaryString.StartsWith("000010"))
            return new SUBWF(binaryString, pic);
        if (binaryString.StartsWith("001110"))
            return new SWAPF(binaryString, pic);
        if (binaryString.StartsWith("000110"))
            return new XORWF(binaryString, pic);
        if (binaryString.StartsWith("0100"))
            return new BCF(binaryString, pic);
        if (binaryString.StartsWith("0101"))
            return new BSF(binaryString, pic);
        if (binaryString.StartsWith("0110"))
            return new BTFSC(binaryString, pic);
        if (binaryString.StartsWith("0111"))
            return new BTFSS(binaryString, pic);
        if (binaryString.StartsWith("11111"))
            return new ADDLW(binaryString, pic);
        if (binaryString.StartsWith("111001"))
            return new ANDLW(binaryString, pic);
        if (binaryString.StartsWith("100"))
            return new CALL(binaryString, pic);
        if (binaryString.StartsWith("00000001100100"))
            return new CLRWDT(binaryString, pic);
        if (binaryString.StartsWith("101"))
            return new GOTO(binaryString, pic);
        if (binaryString.StartsWith("111000"))
            return new IORLW(binaryString, pic);
        if (binaryString.StartsWith("1100"))
            return new MOVLW(binaryString, pic);
        if (binaryString.StartsWith("00000000001001"))
            return new RETFIE(binaryString, pic);
        if (binaryString.StartsWith("1101"))
            return new RETLW(binaryString, pic);
        if (binaryString.StartsWith("00000000001000"))
            return new RETURN(binaryString, pic);
        if (binaryString.StartsWith("00000001100011"))
            return new SLEEP(binaryString, pic);
        if (binaryString.StartsWith("11110"))
            return new SUBLW(binaryString, pic);
        if (binaryString.StartsWith("111010"))
            return new XORLW(binaryString, pic);


        // ERROR
        throw new Exception("Cannot decode opcode: " + binaryString);
    }
}