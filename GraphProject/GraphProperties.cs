namespace GraphProject;

public partial class Graph
{

    private class Edge : IComparable<Edge>
    {
        public int src, dest, weight;

        public Edge(int src, int dest, int weight)
        {
            this.src = src;
            this.dest = dest;
            this.weight = weight;
        }

        public int CompareTo(Edge other)
        {
            return weight.CompareTo(other.weight);
        }
    }
    public bool IsUndirected()
    {
        for (int i = 0; i<vertices; ++i)
        {
            foreach (int j in adj[i])
            {
                if (!adj[j].Contains(i))
                    return false;
            }
        }

        return true;
    }

    public bool IsCircular()
    {
        if (vertices < 3)
            return false;

        if (!adj.All(neighbours => neighbours.Count == 2))
            return false;

        var visited = new bool[vertices];
        int start = 0;
        int current = start;
        int count = 0;

        while (current != start)
        {
            if (visited[current])
                return false;

            visited[current] = true;
            count++;

            current = adj[current].FirstOrDefault(n => !visited[n]);

            if (current == -1)
                break;
        }

        return count == vertices && current == start;
    }

    public bool IsBipartite()
    {
        if (vertices == 0)
            return true; // because an empty graph is bipartite

        int[] colours = new int[vertices];
        for (int i = 0; i < vertices; ++i)
            colours[i] = -1; // negative one represents uncoloured

        colours[0] = 1;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);

        do
        {
            int u = queue.Dequeue();

            foreach (int i in adj[u])
            {
                if (colours[i] == -1)
                {
                    colours[i] = 1 - colours[u];
                    queue.Enqueue(i);
                }

                else if (colours[i] == colours[u])
                    return false;
            }
        } while (queue.Count > 0);

        return true;
    }
    public bool IsComplete()
    {
        for (int i = 0; i < vertices; ++i)
        {
            if (adj[i].Count != vertices - 1)
                return false;
        }

        return true;
    }

    public int Degree(int vertex)
    {
        return adj[vertex].Count;
    }

    public int TotalDegree()
    {
        return adj.Sum(list => list.Count);
    }

    public int TotalOutDegree()
    {
        int total = 0;
        for (int i = 0; i < vertices; ++i)
        {
            total += adj[i].Count;
        }

        return total;
    }

    public int TotalInDegree()
    {
        int[] inDegree = new int[vertices];
        for (int i = 0; i < vertices; ++i)
        {
            foreach (int j in adj[i])
            {
                inDegree[j]++;
            }
        }

        return inDegree.Sum();
    }

    public int OutDegree(int vertex)
    {
        if (vertex < 0 || vertex >= vertices)
            throw new ArgumentOutOfRangeException(nameof(vertex), "Vertex index out of range");
        return adj[vertex].Count;
    }
    
    public int InDegree(int vertex)
    {
        if (vertex < 0 || vertex >= vertices)
            throw new ArgumentOutOfRangeException(nameof(vertex), "Vertex index out of range");

        int inDegree = 0;
        for (int i = 0; i < vertices; ++i)
        {
            if (adj[i].Contains(vertex))
            {
                inDegree++;
            }
        }

        return inDegree;
    }
}
