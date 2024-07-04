namespace GraphProject;

public partial class Graph
{
    
    // I will be using Edmonds-Karp approach (using BFS to find augmenting paths).
    public void Fulkerson()
    {
        int[,] rGraph = new int[vertices, vertices];

        for (int u = 0; u < vertices; u++)
        {
            for (int v = 0; v < vertices; v++)
                // assuming capacity 1 for all edges.
                rGraph[u, v] = adj[u].Contains(v) ? 1 : 0;
        }

        int s = 0; // source is vertex 0
        int t = vertices - 1; // sink is the last vertex

        int maxFlow = 0;
        
        // This is different BFS, not the BFS in the GraphTraversal, don't be mistaken.
        while (BFS(rGraph, s, t, out int[] parent))
        {
            int pathFlow = int.MaxValue;
            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                pathFlow = Math.Min(pathFlow, rGraph[u, v]);
            }

            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                rGraph[u, v] -= pathFlow;
                rGraph[v,u] += pathFlow;
            }

            maxFlow += pathFlow;
        }
        
        Console.WriteLine($"The maximum possible flow is {maxFlow}");
    }

    private bool BFS(int[,] rGraph, int s, int t, out int[] parent)
    {
        parent = new int[vertices];
        for (int i = 0; i < vertices; i++)
            parent[i] = -1;

        var visited = new bool[vertices];
        var queue = new Queue<int>();
        queue.Enqueue(s);
        visited[s] = true;
        parent[s] = -1;

        while (queue.Count > 0)
        {
            var u = queue.Dequeue();

            for (int v = 0; v < vertices; v++)
            {
                if (!visited[v] && rGraph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }

        return visited[t];
    }
}