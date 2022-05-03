namespace picSimu.Simulation;

public class CircularStack
{
    private readonly uint[] _elements;
    public const int Length = 8;

    public int Pointer { get; private set; }

    public CircularStack(int count)
    {
        Pointer = 0;
        _elements = new uint[count];
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
        _elements[Pointer % 8] = address;
        Pointer++;
    }

    public uint Get(int i)
    {
        return _elements[i];
    }
}