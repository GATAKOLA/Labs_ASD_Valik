class Program
{
    static void Main()
    {
        var array = new DynamicArray();
        array.Add(10);
        array.Add(20);
        Console.WriteLine($"Array[0] = {array.Get(0)}");

        var stackArray = new StackOnDynamicArray();
        stackArray.Push(5);
        stackArray.Push(7);
        Console.WriteLine($"Peek: {stackArray.Peek()}");
        Console.WriteLine($"Pop: {stackArray.Pop()}");

        var stackList = new LinkedStack();
        stackList.Push(3);
        stackList.Push(9);
        Console.WriteLine($"Peek: {stackList.Peek()}");
        Console.WriteLine($"Pop: {stackList.Pop()}");

        var queue = new LinkedQueue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Console.WriteLine($"Front: {queue.Front()}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}");
    }
}
