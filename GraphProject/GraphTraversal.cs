namespace GraphProject;

public partial class Graph
{
    public void DFS(int startVertex)
    {
        if (startVertex < 0 || startVertex >= vertices)
        {
            Console.WriteLine($"Invalid start vertex: {startVertex}. Must be between 0 and {vertices-1}");
            return;
        }

        var visited = new bool[vertices];
        Console.WriteLine("DFS Traversal: ");
        DFSUtility(startVertex, visited);
        Console.WriteLine();
    }

    private void DFSUtility(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        if (v < 0 || v >= adj.Count)
        {
            Console.WriteLine($"Error: Vertex {v} is out of range!");
            return;
        }

        foreach (int i in adj[v])
        {
            if (i < 0 || i >= vertices)
            {
                Console.WriteLine($"Error: Adjacent vertex {i} of vertex {v} is out of range.");
                continue;
            }
            
            if(!visited[i])
                DFSUtility(i, visited);
        }
    }

    public void BFS(int startVertex)
    {
        var visited = new bool[vertices];
        Console.WriteLine("BFS Traversal: ");
        var queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            startVertex = queue.Dequeue();
            Console.Write(startVertex + " ");
            foreach (int i in adj[startVertex])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }
}