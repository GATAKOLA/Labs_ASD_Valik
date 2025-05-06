using System;
using System.Diagnostics;

class DynamicArray
{
    private int[] buffer;
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    private const int DefaultCapacity = 4;

    public DynamicArray(int capacity = DefaultCapacity)
    {
        Capacity = capacity;
        buffer = new int[Capacity];
        Count = 0;
    }

    public void Add(int value)
    {
        if (Count >= Capacity)
        {
            Resize();
        }
        buffer[Count++] = value;
    }

    public int Get(int index)
    {
        Debug.Assert(index < Count);
        return buffer[index];
    }

    private void Resize()
    {
        Capacity = Capacity == 0 ? DefaultCapacity : Capacity * 2;
        int[] newBuffer = new int[Capacity];
        Array.Copy(buffer, newBuffer, Count);
        buffer = newBuffer;
    }
}
