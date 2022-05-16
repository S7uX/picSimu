namespace picSimu.Simulation;

public class PortA : Port
{
    public PortA(Pic pic, uint portRegisterAddress, uint trisRegisterAddress)
        : base(pic, portRegisterAddress, trisRegisterAddress, 5)
    {
    }

    public override uint ExternalValue
    {
        get => GetValue();
        set
        {
            value &= Mask;

            uint trisReg = Memory.Registers[TrisRegisterAddress];

            if (Memory.ReadRegister(0x81).IsBitSet(5)) // OPTION_REG<5> - Counter mode is selected by setting the T0CS bit
            {
                // TIMER0 source is RA4 (T0CKI) 

                if (trisReg.IsBitSet(4)) // input mode
                {
                    // Check for edge on Pin 4 (T0CKI)
                    bool newValue = value.IsBitSet(4);
                    bool currentValue = GetValue().IsBitSet(4);

                    bool edgeMode = Memory.ReadRegister(0x81).IsBitSet(4); // OPTION_REG<4> - T0SE
                    if (currentValue != newValue) // check edge
                    {
                        if (!newValue && edgeMode) // T0SE := 1 --> increment on falling edge.
                        {
                            Pic.TimerCycle();
                        }
                        else if (newValue && !edgeMode) // T0SE := 0 --> increment on rising edge.
                        {
                            Pic.TimerCycle();
                        }
                    }
                }
            }

            base.ExternalValue = value;
        }
    }
}