using picSimu.Simulation.Instructions;

namespace picSimu.Simulation;

public class CircularStack
{
    private uint[] elements;
    private int pointer;
    public readonly int Length = 8;

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
    
    public uint get(uint i)
    {
        return elements[i];
    }

}