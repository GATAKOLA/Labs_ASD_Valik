using System;
using System.Diagnostics;

class LinkedStack
{
    class Node
    {
        public int Value;
        public Node Next;
        public Node(int value)
        {
            Value = value;
        }
    }

    private Node top;

    public bool IsEmpty() => top == null;

    public void Push(int value)
    {
        var newNode = new Node(value);
        newNode.Next = top;
        top = newNode;
    }

    public int Peek()
    {
        Debug.Assert(!IsEmpty());
        return top.Value;
    }

    public int Pop()
    {
        Debug.Assert(!IsEmpty());
        int value = top.Value;
        top = top.Next;
        return value;
    }
}
