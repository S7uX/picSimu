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