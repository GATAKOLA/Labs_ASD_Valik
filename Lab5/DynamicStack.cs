using System;
using System.Diagnostics;

class StackOnDynamicArray
{
    private DynamicArray array = new DynamicArray();

    public bool IsEmpty() => array.Count == 0;

    public void Push(int value)
    {
        array.Add(value);
    }

    public int Peek()
    {
        Debug.Assert(!IsEmpty());
        return array.Get(array.Count - 1);
    }

    public int Pop()
    {
        Debug.Assert(!IsEmpty());
        int value = array.Get(array.Count - 1);
        array = RemoveLast(array);
        return value;
    }

    private DynamicArray RemoveLast(DynamicArray arr)
    {
        var newArr = new DynamicArray(arr.Count - 1);
        for (int i = 0; i < arr.Count - 1; i++)
        {
            newArr.Add(arr.Get(i));
        }
        return newArr;
    }
}
