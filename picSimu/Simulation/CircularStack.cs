using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class CircularStack
{
    private uint[] elements;
    private int pointer;

    public CircularStack(int count)
    {
        pointer = -1;
        elements = new uint[count];
    }

    public uint pop()
    {
        return elements[pointer-- % 8];
    }

    public void push(uint address)
    {
        pointer++;
        elements[pointer % 8] = address;
    }
}