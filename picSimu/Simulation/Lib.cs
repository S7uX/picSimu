namespace picSimu.Simulation;

public static class Lib
{
    public static bool IsBitSet(this uint b, int pos)
    {
        return (b & (1 << pos)) != 0;
    }

    public static int GetBit(this uint b, int pos)
    {
        return ((b & (1 << pos)) != 0).ToNumber();
    }

    public static int SetBitTo1(this int value, int position)
    {
        // Set a bit at position to 1.
        return value |= (1 << position);
    }

    public static int SetBitTo0(this int value, int position)
    {
        // Set a bit at position to 0.
        return value & ~(1 << position);
    }

    public static uint SetBitTo1(this uint value, int position)
    {
        // Set a bit at position to 1.
        return value |= (1u << position);
    }

    public static uint SetBitTo0(this uint value, int position)
    {
        // Set a bit at position to 0.
        return value & ~(1u << position);
    }

    public static uint SetBit(this uint value, bool bit, int position)
    {
        if (bit)
        {
            return value.SetBitTo1(position);
        }

        return value.SetBitTo0(position);
    }

    public static int ToNumber(this bool value)
    {
        return Convert.ToByte(value);
    }

    public static string ToHexString(this uint value)
    {
        return value.ToString("X2") + "h";
    }

    public static string ToTooltip(this uint value)
    {
        return value + "d" + "\n" + Convert.ToString(value, 2).PadLeft(8, '0') + "b";
    }
    
    public static string TimeTooltip(this double µs)
    {
        double ms = µs / 1000;
        return $"{µs} µs\n{ms.ToString("F0")} ms\n{(ms / 1000).ToString("F2")} s";
    }

    public static bool SameType(object obj, object? comparisonObject)
    {
        if (comparisonObject == null)
        {
            return false;
        }

        return obj.GetType() == comparisonObject.GetType();
    }
}