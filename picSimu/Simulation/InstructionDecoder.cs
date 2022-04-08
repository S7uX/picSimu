using picSimu.Simulation.Instructions;
using picSimu.Simulation.Instructions.ByteOrientedInstructions;

namespace picSimu.Simulation;

public static class InstructionDecoder
{
    public static Instruction? Decode(string instructionHexString)
    {
        string binaryString = String.Join(String.Empty,
            instructionHexString.Select(c => Convert.ToString(Convert.ToInt32
                (c.ToString(), 16), 2).PadLeft(4, '0'))
        );

        if (binaryString.StartsWith("00")) // BYTE-Oriented
        {
            if (binaryString.StartsWith("000111"))
            {
                return new ADDWF(binaryString);
            }
            else if (binaryString.StartsWith("000101"))
            {
                return new ANDWF(binaryString);
            }
            else if (binaryString.StartsWith("0000011"))
            {
                return new CLRF(binaryString);
            }
            else if (binaryString.StartsWith("0000010"))
            {
                return new CLRW(binaryString);
            }
            else if (binaryString.StartsWith("001001"))
            {
                return new COMF(binaryString);
            }
            else if (binaryString.StartsWith("000011"))
            {
                return new DECF(binaryString);
            }
            else if (binaryString.StartsWith("001011"))
            {
                return new DECFSZ(binaryString);
            }
            else if (binaryString.StartsWith("001010"))
            {
                return new INCF(binaryString);
            }
            else if (binaryString.StartsWith("001111"))
            {
                return new INCFSZ(binaryString);
            }
            else if (binaryString.StartsWith("000100"))
            {
                return new IORWF(binaryString);
            }
            else if (binaryString.StartsWith("001000"))
            {
                return new MOVF(binaryString);
            }
            else if (binaryString.StartsWith("0000001"))
            {
                return new MOVWF(binaryString);
            }
            else if (binaryString.StartsWith("0000000") && binaryString.EndsWith("00000"))
            {
                return new NOP(binaryString);
            }
            else if (binaryString.StartsWith("001101"))
            {
                return new RLF(binaryString);
            }
            else if (binaryString.StartsWith("001100"))
            {
                return new RRF(binaryString);
            }
            else if (binaryString.StartsWith("000010"))
            {
                return new SUBWF(binaryString);
            }
            else if (binaryString.StartsWith("001110"))
            {
                return new SWAPF(binaryString);
            }
            else if (binaryString.StartsWith("000110"))
            {
                return new XORWF(binaryString);
            }
        }
        else if (binaryString.StartsWith("01")) //BIT-Oriented
        {
            if (binaryString.StartsWith("0100"))
            {
                return new BCF(binaryString);
            }
            else if (binaryString.StartsWith("0101"))
            {
                return new BSF(binaryString);
            }
            else if (binaryString.StartsWith("0110"))
            {
                return new BTFSC(binaryString);
            }
            else if (binaryString.StartsWith("0111"))
            {
                return new BTFSS(binaryString);
            }
        }
        else
        {
            if (binaryString.StartsWith("11111"))
            {
                return new ADDLW(binaryString);
            }
            else if (binaryString.StartsWith("111001"))
            {
                return new ANDLW(binaryString);
            }
            else if (binaryString.StartsWith("100"))
            {
                return new CALL(binaryString);
            }
            else if (binaryString.StartsWith("00000001100100"))
            {
                return new CLRWDT(binaryString);
            }
            else if (binaryString.StartsWith("101"))
            {
                return new GOTO(binaryString);
            }
            else if (binaryString.StartsWith("111000"))
            {
                return new IORLW(binaryString);
            }
            else if (binaryString.StartsWith("1100"))
            {
                return new MOVLW(binaryString);
            }
            else if (binaryString.StartsWith("00000000001001"))
            {
                return new RETFIE(binaryString);
            }
            else if (binaryString.StartsWith("1101"))
            {
                return new RETLW(binaryString);
            }
            else if (binaryString.StartsWith("00000000001000"))
            {
                return new RETURN(binaryString);
            }
            else if (binaryString.StartsWith("00000001100011"))
            {
                return new SLEEP(binaryString);
            }
            else if (binaryString.StartsWith("11110"))
            {
                return new SUBLW(binaryString);
            }
            else if (binaryString.StartsWith("111010"))
            {
                return new XORLW(binaryString);
            }
        }


        //FEHLER
        return null;
    }
}