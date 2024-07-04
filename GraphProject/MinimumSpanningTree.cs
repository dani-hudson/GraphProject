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

            foreach (int v in adj[u])
            {
                if (!mstSet[v] && adj[u].Contains(v) && key[v] > 1) // weight 1 for all edges
                {
                    parent[v] = u;
                    key[v] = 1;
                }
            }
        }
        PrintMST(parent);
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

    private void PrintMST(int[] parent)
    {
        Console.WriteLine("Edge \tWeight");
        for(int i =1 ; i<vertices; i++)
            Console.WriteLine($"{parent[i]} - {i}\t1");
    }

    public void Kruskal()
    {
        var edges = new List<Edge>();
        for (int i = 0; i < vertices; i++)
        {
            foreach (int j in adj[i])
            {
                if(i<j) // avoid duplicates.
                    edges.Add((new Edge(i,j,1))); // weight 1 for all edges
            }
        }
        
        edges.Sort((a,b) => a.weight.CompareTo(b.weight));

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