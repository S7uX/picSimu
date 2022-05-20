namespace picSimu.Simulation;

public class Memory
{
    private Pic _pic;
    public const uint MemoryLength = 256;
    public readonly uint[] Registers = new uint[MemoryLength];
    public readonly Port PortA;
    public readonly Port PortB;

    public bool MCLRPIN = true;

    public Memory(Pic pic)
    {
        pic.Memory = this;
        _pic = pic;
        PortA = new PortA(_pic, 5, 0x85);
        PortB = new PortB(_pic, 6, 0x86);
        PowerOnReset();
    }

    public uint Pcl // 8-bits wide
    {
        get => ReadRegister(2) & 0b_1111_1111;
        set => WriteRegister(2, value & 0b_1111_1111);
    }

    public bool BankSelect => Registers[3].IsBitSet(5);

    #region Reset

    public void PowerOnReset()
    {
        WriteRegister(0x03, 0b_00011000); // STATUS
        WriteRegister(0x81, 0b_11111111); // OPTION_REG
        WriteRegister(0x85, 0b_00011111); // TRISA
        WriteRegister(0x86, 0b_11111111); // TRISB
    }

    public void WatchDogReset()
    {
        uint status = 0;
        if (_pic.IsSleeping)
        {
            status = ReadRegister(0x03)
                .SetBitTo0(4)
                .SetBitTo1(3); // PD STATUS<3> = 1 for wake up
            _pic.ProgramCounter++;
        }
        else
        {
            // WDT Time-out: normal operation
            AllOtherResets();
            status = ReadRegister(0x03)
                .SetBitTo0(4)
                .SetBitTo1(3);
            _pic.EEPROM.Terminate();
        }

        WriteRegister(0x03, status); // STATUS
    }

    /// <summary>
    /// Master Clear
    /// </summary>
    public void MCLR()
    {
        AllOtherResets();
        if (_pic.IsSleeping)
        {
            uint status = ReadRegister(0x03)
                .SetBitTo1(4) // TO
                .SetBitTo1(3); // PD STATUS<3> = 1 for wake up
            WriteRegister(0x03, status); // STATUS
        }

        _pic.EEPROM.Terminate();
    }

    public void AllOtherResets()
    {
        _pic.ProgramCounter = 0;
        uint status = ReadRegister(0x03) & 0b_0001_1111;
        WriteRegister(0x03, status); // STATUS
        WriteRegister(0x0A, 0); // PCLATH
        // INTCON
        uint intcon = ReadRegister(0x0B) & 0b_0000_0001;
        WriteRegister(0x02, intcon);
        WriteRegister(0x81, 0b_1111_1111); // OPTION
        WriteRegister(0x85, 0b_00011111); // TRISA
        WriteRegister(0x86, 0b_11111111); // TRISB
        uint eecon_1 = ReadRegister(0x0B);
        eecon_1.SetBitTo0(0);
        eecon_1.SetBitTo0(1);
        eecon_1.SetBitTo0(2);
        eecon_1.SetBitTo0(4);
        WriteRegister(0x0B, eecon_1); // EECON_1
    }

    #endregion Reset

    public uint FSR => Registers[4];

    public void SetCarryFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 0));
    }

    public bool GetCarryFlag()
    {
        return ReadRegister(3).IsBitSet(0);
    }

    public void SetDigitCarryFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 1));
    }

    public bool GetDigitCarryFlag()
    {
        return ReadRegister(3).IsBitSet(1);
    }

    public void SetZeroFlag(bool zeroFlag)
    {
        WriteRegister(3, ReadRegister(3).SetBit(zeroFlag, 2));
    }

    public bool GetZeroFlag()
    {
        return ReadRegister(3).IsBitSet(2);
    }

    private uint _calculateAddressWithRp0(uint address)
    {
        if (!BankSelect) // rp0 bit
        {
            // bank 0
            return address.SetBitTo0(7);
        }
        else
        {
            // bank 1
            return address.SetBitTo1(7);
        }
    }


    public uint ReadRegisterForInstructions(uint address)
    {
        return ReadRegister(_calculateAddressWithRp0(address));
    }

    public uint ReadRegister(uint address)
    {
        if ((0x30 <= address && 0x7F >= address) || (0xD0 <= address && 0xFF >= address) || address == 7) // Unimplemented data memory location; read as ’0’.
        {
            return 0;
        }

        switch (address)
        {
            case 0: // Indirect addr.
            case 0x80:
                if (FSR == 0) return 0; // prevent infinite loop
                return ReadRegister(Registers[4]);
            case 0x02: // PCL
            case 0x82:
                return Registers[2];
            case 0x03: // STATUS
            case 0x83:
                return Registers[3];
            case 0x04: // FSR
            case 0x84:
                return Registers[4];
            case 0x05: // PORTA
                return PortA.InternalValue;
            case 0x85: // TRISA
                return Registers[0x85] & 0b_00011111;
            case 0x06: // PORTB
                return PortB.InternalValue;
            case 0x86: // TRISB
                return Registers[0x86];
            case 0x0A: // PCLATH
            case 0x8A:
                return Registers[0x0A] & 0b_00011111;
            case 0x0B: // INTCON
            case 0X8B:
                return Registers[0x0B];
            case 0x89: // EEPROM
                return _pic.EEPROM.EECON2;
        }

        return Registers[address];
    }

    public void WriteRegisterForInstructions(uint address, uint value)
    {
        address = _calculateAddressWithRp0(address);
        if (address is 2 or 0x82) // PCL reg.
        {
            value &= 0b_1111_1111; // mask low byte 
            uint pclath = ReadRegister(0x0A) & 0b_0001_1111; // PC high byte (bits <12:8>) from PCLATH 
            pclath <<= 8; // high byte
            value |= pclath; // PCLATH register <4:0> bits <--> high byte bits PC<12:8>
            _pic.ProgramCounter = value;
        }
        else
        {
            WriteRegister(_calculateAddressWithRp0(address), value);
        }
    }

    public void WriteRegister(uint address, uint value)
    {
        // Unimplemented data memory location; do nothing
        if ((0x30 <= address && 0x7F >= address) || (0xD0 <= address && 0xFF >= address) || address == 7)
        {
            return;
        }

        switch (address)
        {
            case 0: // Indirect addr
            case 0x80:
                if (FSR == 0) break; // prevent infinite recursion 
                WriteRegister(Registers[4], value);
                break;
            case 1: // TIMER0
                if (!ReadRegister(0x81).IsBitSet(3))
                {
                    // IF Prescaler is assigned to TMR0 (PSA = 0)
                    _pic.ResetScaler();
                }

                Registers[1] = value;
                break;
            case 0x81: // OPTION 
                uint currentOptionRegister = ReadRegister(0x81);
                Registers[0x81] = value;
                if (
                    (currentOptionRegister.IsBitSet(0) ^ value.IsBitSet(0))
                    || (currentOptionRegister.IsBitSet(1) ^ value.IsBitSet(1))
                    || (currentOptionRegister.IsBitSet(2) ^ value.IsBitSet(2))
                )
                {
                    if (_pic.Memory != null)
                    {
                        _pic.ResetScaler();
                    }
                }

                break;
            case 0x02: // PCL; low byte program counter
            case 0x82:
                Registers[2] = value;
                Registers[0x82] = value;
                break;
            case 0x03: // STATUS
            case 0x83:
                Registers[3] = value;
                Registers[0x83] = value;
                break;
            case 0x04: // FSR
            case 0x84:
                Registers[4] = value;
                Registers[0X84] = value;
                break;
            case 0x05: // PORTA
                PortA.InternalValue = value;
                break;
            case 0x85: // TRISA
                Registers[0x85] = value & 0b_00011111;
                break;
            case 0x06:
                PortB.InternalValue = value;
                break;
            case 0x86: // TRISB
                Registers[0x86] = value;
                break;
            case 0x0A: // PCLATH
            case 0x8A:
                // first three unimplemented
                Registers[0x0A] = value & 0b_00011111;
                Registers[0x8A] = value & 0b_00011111;
                break;
            case 0x0B: // INTCON
            case 0x8B:
                Registers[0x0B] = value;
                Registers[0x8B] = value;
                break;
            case 0x08:
                _pic.EEPROM.EEDATA = value;
                break;
            case 0x88:
                _pic.EEPROM.EECON1 = value;
                break;
            case 0x09:
                _pic.EEPROM.EEADR = value;
                break;
            case 0x89:
                _pic.EEPROM.EECON2 = value;
                break;
            default:
                Registers[address] = value;
                break;
        }
    }

    #region blazor data bindings

    public RegisterBit GetRegisterBit(uint address, int bit)
    {
        return new RegisterBit(this, address, bit);
    }

    public Register GetRegister(uint address)
    {
        return new Register(this, address);
    }

    #endregion blazor data bindings
}