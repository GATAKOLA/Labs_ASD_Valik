using System;
using System.Diagnostics;


public class SinglyLinkedList<T>
{
    public class Node
    {
        public T Value;
        public Node Next;
        public Node(T value) { Value = value; Next = null; }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; } = 0;

    public Node InsertAfter(Node node, T value)
    {
        var newNode = new Node(value);
        if (node == null)
        {
            newNode.Next = Head;
            Head = newNode;
            if (Tail == null) Tail = newNode;
        }
        else
        {
            newNode.Next = node.Next;
            node.Next = newNode;
            if (node == Tail) Tail = newNode;
        }
        Count++;
        return newNode;
    }

    public (Node prev, Node found) Find(T value)
    {
        Node prev = null, current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value)) return (prev, current);
            prev = current;
            current = current.Next;
        }
        return (null, null);
    }

    public void RemoveAfter(Node node)
    {
        if (node == null)
        {
            if (Head != null) Head = Head.Next;
            if (Head == null) Tail = null;
        }
        else if (node.Next != null)
        {
            if (node.Next == Tail) Tail = node;
            node.Next = node.Next.Next;
        }
        Count--;
    }

    public void AssertNoCycles()
    {
        int actualCount = 0;
        Node current = Head;
        while (current != null)
        {
            actualCount++;
            current = current.Next;
            Debug.Assert(actualCount <= Count, "Цикл обнаружен в списке!");
        }
    }
}

public class DoublyLinkedList<T>
{
    public class Node
    {
        public T Value;
        public Node Next, Prev;
        public Node(T value) { Value = value; }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; } = 0;

    public Node InsertAfter(Node node, T value)
    {
        var newNode = new Node(value);
        if (node == null)
        {
            newNode.Next = Head;
            if (Head != null) Head.Prev = newNode;
            Head = newNode;
            if (Tail == null) Tail = newNode;
        }
        else
        {
            newNode.Next = node.Next;
            newNode.Prev = node;
            if (node.Next != null) node.Next.Prev = newNode;
            node.Next = newNode;
            if (node == Tail) Tail = newNode;
        }
        Count++;
        return newNode;
    }

    public Node InsertBefore(Node node, T value)
    {
        var newNode = new Node(value);
        if (node == null || node == Head)
        {
            newNode.Next = Head;
            if (Head != null) Head.Prev = newNode;
            Head = newNode;
            if (Tail == null) Tail = newNode;
        }
        else
        {
            newNode.Prev = node.Prev;
            newNode.Next = node;
            node.Prev.Next = newNode;
            node.Prev = newNode;
        }
        Count++;
        return newNode;
    }

    public Node Find(T value)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value)) return current;
            current = current.Next;
        }
        return null;
    }

    public void Remove(Node node)
    {
        if (node == null) return;
        if (node == Head) Head = node.Next;
        if (node == Tail) Tail = node.Prev;
        if (node.Prev != null) node.Prev.Next = node.Next;
        if (node.Next != null) node.Next.Prev = node.Prev;
        Count--;
    }

    public void AssertNoCycles()
    {
        int actualCount = 0;
        Node current = Head;
        while (current != null)
        {
            actualCount++;
            current = current.Next;
            Debug.Assert(actualCount <= Count, "Цикл обнаружен в списке!");
        }
    }
}


class Program
{
    static void Main()
    {
        var singlyList = new SinglyLinkedList<int>();
        var node1 = singlyList.InsertAfter(null, 1);
        var node2 = singlyList.InsertAfter(node1, 2);
        singlyList.InsertAfter(node2, 3);
        Debug.Assert(singlyList.Find(2).found != null);
        singlyList.RemoveAfter(node1);
        singlyList.AssertNoCycles();

        var doublyList = new DoublyLinkedList<int>();
        var dNode1 = doublyList.InsertAfter(null, 10);
        var dNode2 = doublyList.InsertAfter(dNode1, 20);
        doublyList.InsertBefore(dNode2, 15);
        Debug.Assert(doublyList.Find(15) != null);
        doublyList.Remove(dNode1);
        doublyList.AssertNoCycles();

        Console.WriteLine("Все тесты пройдены.");
    }
}
