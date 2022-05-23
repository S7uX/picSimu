using picSimu.Simulation.Instructions;
using picSimu.Simulation.Instructions.BitOrientedInstructions;
using picSimu.Simulation.Instructions.ByteOrientedInstructions;
using picSimu.Simulation.Instructions.LiteralInstructions;

namespace picSimu.Simulation;

public class EEPROM
{
    public const int LENGTH = 64;
    public readonly uint[] Cells = new uint[LENGTH];
    private readonly Pic _pic;
    private readonly Memory _memory;
    private bool _isWriting = false;
    private double _writeStartingValue = 0;

    private static readonly Instruction[] _requiredInstructionSequenceForWrite =
    {
        new MOVWF(9, 1), // EECON2
        new MOVLW(0xAA),
        new MOVWF(9, 1), // EECON2
        new BSF(8, 1), // Set WR bit --> begin write
    };

    private int _nextRequiredInstructionForWrite = 0;
    private bool _sequenceOccurred => _nextRequiredInstructionForWrite == _requiredInstructionSequenceForWrite.Length;


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
            value &= 0b_0001_1111; // bit <7:5> unimplemented
            if (
                !EECON1.IsBitSet(2) // The WR bit will be inhibited from being set unless the WREN bit is set.
                ||
                !value.IsBitSet(1) // WR bit can only be set (not cleared) in software.
            )
            {
                value = value.SetBit(_memory.Registers[0x88].IsBitSet(1), 1);
            }

            if (!value.IsBitSet(0)) // The RD bit can only be set (not cleared) in software).
            {
                value = value.SetBit(_memory.Registers[0x88].IsBitSet(0), 0);
            }

            _memory.Registers[0x88] = value;

            if (value.IsBitSet(1) && _sequenceOccurred) // WR a write cycle.
            {
                _write();
            }

            if (value.IsBitSet(0)) // RD Initiates an EEPROM read
            {
                _read();
            }
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

    public void CheckInstruction(Instruction? instruction)
    {
        if (instruction == null)
        {
            _nextRequiredInstructionForWrite = 0;
        }
        else
        {
            if (_nextRequiredInstructionForWrite == _requiredInstructionSequenceForWrite.Length)
            {
                _nextRequiredInstructionForWrite = 0;
            }

            Instruction expected = _requiredInstructionSequenceForWrite[_nextRequiredInstructionForWrite];
            if (instruction.Equals(expected))
            {
                _nextRequiredInstructionForWrite++;
            }
            else
            {
                _nextRequiredInstructionForWrite = 0;
            }
        }
    }

    private void _read()
    {
        Console.WriteLine("EEPROM READ");
        EEDATA = Cells[EEADR];
        _memory.Registers[0x88] = EECON1.SetBit(false, 0); // clear RD bit
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
    private void _write()
    {
        if (EECON1.IsBitSet(2) /* WREN bit */ && _sequenceOccurred)
        {
            Console.WriteLine("EEPROM WRITE");
            _isWriting = true;
        }
    }

    public void CompleteWrite()
    {
        if (_isWriting)
        {
            if (_writeStartingValue == 0)
            {
                _writeStartingValue = _pic.CalculateRuntime();
            }
            else if (_pic.CalculateRuntime() - _writeStartingValue >= 1000) // 1 ms write time
            {
                Cells[EEADR] = EEDATA;
                EEDATA = Cells[EEADR];
                _memory.Registers[0x88] = EECON1.SetBit(false, 1) // clear WR bit
                    .SetBit(true, 4); // set EEIF bit 
                _isWriting = false;
                _writeStartingValue = 0;
                Console.WriteLine("EEPROM WRITE FINISHED");
            }

            if (_memory.ReadRegister(0x0B).IsBitSet(6)) // EEIE: EE Write Complete Interrupt Enable bit - INTCON<6>
            {
                _pic.Interrupt();
            }
        }
    }

    public void Terminate()
    {
        _isWriting = false;
        _writeStartingValue = 0;
        EECON1 &= 0b_11101000;
    }
}