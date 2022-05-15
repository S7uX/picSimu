using picSimu.Simulation.Instructions;
using picSimu.Simulation.Instructions.BitOrientedInstructions;
using picSimu.Simulation.Instructions.ByteOrientedInstructions;
using picSimu.Simulation.Instructions.LiteralInstructions;

namespace picSimu.Simulation;

public class EEPROM
{
    public const int Length = 64;
    public readonly uint[] Cells = new uint[Length];
    private Pic _pic;
    private Memory _memory;
    private bool _isWriting = false;

    public static readonly Instruction[] RequiredInstructionSequenceForWrite =
    {
        new MOVWF(1, 0x89), // EECON2
        new MOVLW(0xAA),
        new MOVWF(1, 0x55), // EECON2
        new MOVWF(1, 0x55), // EECON2
        new BSF(0x88, 1), // Set WR bit --> begin write
    };

    private int _nextRequiredInstructionForWrite = 0;
    private bool _sequenceOccurred => _nextRequiredInstructionForWrite == RequiredInstructionSequenceForWrite.Length;

    public EEPROM(Pic pic)
    {
        _pic = pic;
        _memory = pic.Memory;
    }

    public uint EEDATA
    {
        get => _memory.Registers[8];
        set => _memory.Registers[8] = value & 0b_1111_1111;
    }

    /// <summary>
    /// control register
    /// </summary>
    public uint EECON1
    {
        get => _memory.Registers[0x88];
        set
        {
            value &= 0001_1111; // bit <7:5> unimplemented
            if (
                EECON1.IsBitSet(2) // The WR bit will be inhibited from being set unless the WREN bit is set.
                ||
                !value.IsBitSet(1) // WR bit can only be set (not cleared) in software.
            )
            {
                value = value.SetBit(_memory.Registers[0x88].IsBitSet(1), 2);
            }

            if (!value.IsBitSet(0)) // The RD bit can only be set (not cleared) in software).
            {
                value = value.SetBit(_memory.Registers[0x88].IsBitSet(1), 2);
            }

            _memory.Registers[0x88] = value;
        }
    }

    /// <summary>
    /// address range from 0h to 3Fh (64 data bytes)
    /// </summary>
    public uint EEADR
    {
        get => _memory.Registers[9];
        set => _memory.Registers[9] = value & 0b_1111_1111;
    }

    /// <summary>
    /// - Used exclusively in the Data EEPROM write sequence.
    /// - Not a physical register: All bits read as 0.
    /// </summary>
    public uint EECON2
    {
        get => 0;
        set
        {
            // ignore
        }
    }

    public void CheckInstruction(Instruction instruction)
    {
        Instruction expected = RequiredInstructionSequenceForWrite[_nextRequiredInstructionForWrite];
        for (int i = 0; i < RequiredInstructionSequenceForWrite.Length; i++)
        {
            if (_nextRequiredInstructionForWrite == i && instruction.Equals(expected))
            {
                _nextRequiredInstructionForWrite++;
            }

            _nextRequiredInstructionForWrite = 0;
        }
    }

    public void Read()
    {
        if (EECON1.IsBitSet(0)) // RD bit
        {
            EEDATA = Cells[EEADR];
            _memory.Registers[0x88] = EECON1.SetBit(false, 0); // clear RD bit
        }
    }

    /// <summary>
    /// specific sequence for write:
    /// BSF     STATUS,RP0  ; Bank 1
    /// BCF     INTCON,GIE  ; Disable INTs.
    /// BSF     EECON1,WREN ; Enable Write
    /// MOVLW   55h
    /// ; ---------------------------------- ; required sequence
    /// MOVWF   EECON2      ; Write 55h
    /// MOVLW   AAh;
    /// MOVWF   EECON2      ; Write AAh
    /// BSF     EECON1,WR   ; Set WR bit
    ///                     ; begin write
    /// BSF     INTCON, GIE ; Enable INTs
    /// ; ---------------------------------- ; required sequence
    /// (write 55h to EECON2, write AAh to EECON2, then set WR bit)
    /// </summary>
    public void Write()
    {
        if (EECON1.IsBitSet(2) /* WREN bit */ && _sequenceOccurred)
        {
            _isWriting = true;
        }
    }

    private void _completeWrite()
    {
        Cells[EEADR] = EEDATA;
        EEDATA = Cells[EEADR];
        _memory.Registers[0x88] = EECON1.SetBit(false, 1) // clear WR bit
            .SetBit(true, 6); // set EEIF bit 
        _isWriting = false;
    }
}