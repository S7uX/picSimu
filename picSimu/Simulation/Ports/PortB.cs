namespace picSimu.Simulation;

public class PortB : Port
{
    public PortB(Pic pic, uint portRegisterAddress, uint trisRegisterAddress)
        : base(pic, portRegisterAddress, trisRegisterAddress, 8)
    {
    }

    public override uint ExternalValue
    {
        get => GetValue();
        set
        {
            value &= Mask;

            uint trisReg = Memory.Registers[TrisRegisterAddress];

            if (Memory.ReadRegister(0x0B)
                .IsBitSet(4)) //INTCON_REG<4> - Interrupt RB0/INT is selected by setting the INTE bit
            {
                if (trisReg.IsBitSet(0)) // input mode
                {
                    // Check for edge on Pin 0 (RB0/INT)
                    bool newValue = value.IsBitSet(0);
                    bool currentValue = GetValue().IsBitSet(0);

                    bool edgeMode = Memory.ReadRegister(0x81).IsBitSet(6); // OPTION_REG<6> - NTEDG
                    if (currentValue != newValue) // check edge
                    {
                        if (!newValue && edgeMode) // NTEDG := 1 --> interrupt on falling edge.
                        {
                            // Interrupt is NOT masked
                            Pic.Interrupt();
                            Memory.WriteRegister(0x0B,
                                Memory.ReadRegister(0x0B)
                                    .SetBitTo1(1)); //(INTF) Set Flag that RB0/INT Interrupt occured
                        }
                        else if (newValue && !edgeMode) // NTEDG := 0 --> interrupt on rising edge.
                        {
                            // Interrupt is NOT masked
                            Pic.Interrupt();
                            Memory.WriteRegister(0x0B,
                                Memory.ReadRegister(0x0B)
                                    .SetBitTo1(1)); //(INTF) Set Flag that RB0/INT Interrupt occured
                        }
                    }
                }
            }

            if (Memory.ReadRegister(0x0B)
                .IsBitSet(3)) //INTCON_REG<3> - Interrupt RBIE is selected by setting the RBIE bit
            {
                if (trisReg.IsBitSet(4)) // input mode
                {
                    // Check for edge on Pin 4 (RB0/INT)
                    bool newValue = value.IsBitSet(4);
                    bool currentValue = GetValue().IsBitSet(4);

                    if (currentValue != newValue) // check change
                    {
                        // Interrupt is NOT masked
                        Pic.Interrupt();
                        Memory.WriteRegister(0x0B,
                            Memory.ReadRegister(0x0B).SetBitTo1(0)); //(RBIF) Set Flag that RB Port change Interrupt occured
                    }
                }
                if (trisReg.IsBitSet(5)) // input mode
                {
                    // Check for edge on Pin 5 (RB0/INT)
                    bool newValue = value.IsBitSet(5);
                    bool currentValue = GetValue().IsBitSet(5);

                    if (currentValue != newValue) // check change
                    {
                        // Interrupt is NOT masked
                        Pic.Interrupt();
                        Memory.WriteRegister(0x0B,
                            Memory.ReadRegister(0x0B).SetBitTo1(0)); //(RBIF) Set Flag that RB Port change Interrupt occured
                    }
                }
                if (trisReg.IsBitSet(6)) // input mode
                {
                    // Check for edge on Pin 6 (RB0/INT)
                    bool newValue = value.IsBitSet(6);
                    bool currentValue = GetValue().IsBitSet(6);

                    if (currentValue != newValue) // check change
                    {
                        // Interrupt is NOT masked
                        Pic.Interrupt();
                        Memory.WriteRegister(0x0B,
                            Memory.ReadRegister(0x0B).SetBitTo1(0)); //(RBIF) Set Flag that RB Port change Interrupt occured
                    }
                }
                if (trisReg.IsBitSet(7)) // input mode
                {
                    // Check for edge on Pin 7 (RB0/INT)
                    bool newValue = value.IsBitSet(7);
                    bool currentValue = GetValue().IsBitSet(7);

                    if (currentValue != newValue) // check change
                    {
                        // Interrupt is NOT masked
                        Pic.Interrupt();
                        Memory.WriteRegister(0x0B,
                            Memory.ReadRegister(0x0B).SetBitTo1(0)); //(RBIF) Set Flag that RB Port change Interrupt occured
                    }
                }
            }

            base.ExternalValue = value;
        }
    }
}