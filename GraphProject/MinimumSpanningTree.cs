namespace GraphProject;

public partial class Graph
{
    public void Prim(int startVertex)
    {
        var parent = new int[vertices];
        var key = new int[vertices];
        var mstSet = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[startVertex] = 0;
        parent[startVertex] = -1;

        for (int count = 0; count < vertices - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            for (int v = 0; v < vertices; v++)
            {
                if (weights[u, v] > 0 && !mstSet[v] && weights[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = weights[u, v];
                }
            }
        }

        PrintMST(parent, key);
    }

    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < vertices; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private void PrintMST(int[] parent, int[] key)
    {
        Console.WriteLine("Edge \tWeight");
        int mstWeight = 0;
        for (int i = 1; i < vertices; i++)
        {
            Console.WriteLine($"{parent[i]} - {i}\t{key[i]}");
            mstWeight += key[i];
        }

        Console.WriteLine("Weight of the MST: " + mstWeight);
    }

    public void Kruskal()
    {
        var edges = new List<Edge>();
        for (int i = 0; i < vertices; i++)
        {
            for (int j = i + 1; j < vertices; j++)
            {
                if (weights[i, j] > 0)
                {
                    edges.Add(new Edge(i, j, weights[i, j]));
                }
            }
        }
        
        edges.Sort();

        var disjoinSet = new DisjoinSet(vertices);
        var result = new List<Edge>();

        foreach (Edge edge in edges)
        {
            if (disjoinSet.Find(edge.src) != disjoinSet.Find(edge.dest))
            {
                result.Add(edge);
                disjoinSet.Union(edge.src,edge.dest);
            }
        }
        
        Console.WriteLine("Edges in the MST: ");
        foreach (Edge edge in result)
        {
            Console.WriteLine($"{edge.src} - {edge.dest}\tWeight: {edge.weight}");
        }
    }

    private class DisjoinSet
    {
        private int[] parent;

        public DisjoinSet(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++)
                parent[i] = i;
        }

        public int Find(int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent[i]);
            return parent[i];
        }

        public void Union(int x, int y)
        {
            var xroot = Find(x);
            var yroot = Find(y);
            parent[xroot] = yroot;
        }
    }
}