using System;
using System.Collections.Generic;

class GraphNode
{
    public int Value;
    public List<GraphNode> Neighbors = new List<GraphNode>();

    public GraphNode(int value)
    {
        Value = value;
    }
}

class Program
{
    static void PrintNeighborsOfNeighbors(GraphNode node)
    {
        foreach (var neighbor in node.Neighbors)
        {
            foreach (var neighborsNeighbor in neighbor.Neighbors)
            {
                Console.WriteLine(neighborsNeighbor.Value);
            }
        }
    }

    static int SumOfNeighbors(GraphNode node)
    {
        int sum = 0;
        foreach (var neighbor in node.Neighbors)
        {
            sum += neighbor.Value;
        }
        return sum;
    }

    static void DFS(GraphNode node, HashSet<GraphNode> visited)
    {
        if (visited.Contains(node)) return;

        Console.WriteLine(node.Value);
        visited.Add(node);

        foreach (var neighbor in node.Neighbors)
        {
            DFS(neighbor, visited);
        }
    }

    static void BFS(GraphNode start)
    {
        var visited = new HashSet<GraphNode>();
        var queue = new Queue<GraphNode>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current)) continue;

            Console.WriteLine(current.Value);
            visited.Add(current);

            foreach (var neighbor in current.Neighbors)
            {
                if (!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
            }
        }
    }

    static void Main()
    {
        var n1 = new GraphNode(1);
        var n2 = new GraphNode(2);
        var n3 = new GraphNode(3);
        var n4 = new GraphNode(4);

        n1.Neighbors.Add(n2);
        n1.Neighbors.Add(n3);
        n1.Neighbors.Add(n4);

        n2.Neighbors.Add(n1);
        n2.Neighbors.Add(n3);

        n3.Neighbors.Add(n1);
        n3.Neighbors.Add(n2);
        n3.Neighbors.Add(n4);

        n4.Neighbors.Add(n1);
        n4.Neighbors.Add(n3);

        Console.WriteLine("Соседи соседей узла 2:");
        PrintNeighborsOfNeighbors(n2);

        Console.WriteLine("\nСумма значений соседей узла 3:");
        Console.WriteLine(SumOfNeighbors(n3));

        Console.WriteLine("\nDFS от узла 1:");
        DFS(n1, new HashSet<GraphNode>());

        Console.WriteLine("\nBFS от узла 1:");
        BFS(n1);
    }
}


/*
В направленном графе связь между узлами односторонняя: если A ссылается на B, то в памяти A.Neighbors содержит B, а B.Neighbors — ничего.
Примерно так:
A.Neighbors = [B]
B.Neighbors = [ ]

В ненаправленном графе связь двусторонняя: при добавлении ребра между A и B, оба узла ссылаются друг на друга. Исходя из этого A.Neighbors содержит B и B.Neighbors содержит A.
Примерно так:
A.Neighbors = [B]
B.Neighbors = [A]

Таким образом, в памяти направленный граф хранит только односторонние ссылки, а ненаправленный — парные.
*/

