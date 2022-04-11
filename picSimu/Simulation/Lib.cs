namespace picSimu.Simulation;

public static class Lib
{
    public static bool IsBitSet(ushort b, int pos)
    {
        return (b & (1 << pos)) != 0;
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
}