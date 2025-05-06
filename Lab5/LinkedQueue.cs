using System;
using System.Diagnostics;

class LinkedQueue
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

    private Node head;
    private Node tail;

    public bool IsEmpty() => head == null;

    public void Enqueue(int value)
    {
        var newNode = new Node(value);
        if (tail != null)
            tail.Next = newNode;
        else
            head = newNode;

        tail = newNode;
    }

    public int Front()
    {
        Debug.Assert(!IsEmpty());
        return head.Value;
    }

    public int Dequeue()
    {
        Debug.Assert(!IsEmpty());
        int value = head.Value;
        head = head.Next;
        if (head == null) tail = null;
        return value;
    }
}
