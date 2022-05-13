namespace picSimu.Simulation;

public class Stack
{
    private readonly uint[] _elements;
    public readonly int Length;

    public int Pointer { get; private set; }

    public Stack(int count) // 13 bit wide
    {
        Length = count;
        Pointer = 0;
        _elements = new uint[Length];
    }

    public uint Pop()
    {
        if (Pointer == 0)
        {
            Pointer = 7;
        }
        else
        {
            Pointer--;
        }

        return _elements[Pointer % 8];
    }

    public void Push(uint address)
    {
        _elements[Pointer % 8] = address & 0b_1_1111_1111_1111;
        Pointer++;
    }

    public uint Get(int i)
    {
        return _elements[i];
    }
}