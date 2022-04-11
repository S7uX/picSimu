namespace picSimu.Simulation;

public static class Lib
{
    public static bool IsBitSet(ushort b, int pos)
    {
        return (b & (1 << pos)) != 0;
    }
}