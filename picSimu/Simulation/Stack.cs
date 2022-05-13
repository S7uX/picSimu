namespace picSimu.Simulation;

public class Stack
{
    private readonly uint[] _elements;
    public const int Length = 8;

    public int Pointer { get; private set; }

    public Stack() // 13 bit wide
    {
        Pointer = 0;
        _elements = new uint[Length];
    }

    public uint Pop()
    {
        if (Pointer == 0)
        {
            Pointer = Length - 1;
        }
        else
        {
            Pointer--;
        }

        return _elements[Pointer % Length];
    }

    public void Push(uint address)
    {
        _elements[Pointer % Length] = address & 0b_1_1111_1111_1111;
        Pointer++;
    }

    public uint Get(int i)
    {
        return _elements[i];
    }
}