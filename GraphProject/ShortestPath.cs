namespace GraphProject;

public partial class Graph
{
    public void Dijkstra(int startVertex)
    {
        var dist = new int[vertices];
        var sptSet = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        dist[startVertex] = 0;

        for (int count = 0; count < vertices - 1; count++)
        {
            int x = MinDistance(dist, sptSet);
            sptSet[x] = true;

            foreach (int v in adj[x])
            {
                if (!sptSet[v] && dist[x] != int.MaxValue && dist[x] + 1 < dist[v])
                    dist[v] = dist[x] + 1;
            }
        }
        
        PrintPath(dist);
        
    }

    private int MinDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int i = 0; i < vertices; i++)
        {
            if (!sptSet[i] && dist[i] <= min)
            {
                min = dist[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    private void PrintPath(int[] dist)
    {
        Console.WriteLine("Vertex \t\t Distance from source");
        for (int i = 0; i< vertices; i++)
            Console.WriteLine($"{i} \t\t {dist[i]}");
    }

    public void BellmanFord(int startVertex)
    {
        var dist = new int[vertices];
        for (int i = 0; i < vertices; i++)
            dist[i] = int.MaxValue;

        dist[startVertex] = 0;

        for (int i = 1; i < vertices; i++)
        {
            for (int x = 0; x < vertices; x++)
            {
                foreach (int v in adj[x])
                {
                    if (dist[x] != int.MaxValue && dist[x] + 1 < dist[v])
                        dist[v] = dist[x] + 1;
                }
            }
        }

        for (int x = 0; x < vertices; x++)
        {
            foreach (int v in adj[x])
            {
                if (dist[x] != int.MaxValue && dist[x] + 1 < dist[v])
                {
                    Console.WriteLine("Graph contains negative weight cycle.");
                    return;
                }
            }
        }

        PrintPath(dist);
    }
}