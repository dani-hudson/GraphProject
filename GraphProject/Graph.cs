namespace GraphProject;

public partial class Graph
{
    private int vertices; // vertices
    private List<List<int>> adj; // adjacency
    private int[,] capacities; // capacities
    private int[,] weights; // weights
    public int VertexCount => vertices;

    public Graph()
    {
        adj = new List<List<int>>();
    }


    public void ReadPath(string path)
    {
        var lines = File.ReadAllLines(path);
        vertices = int.Parse(lines[0]);
        adj = new List<List<int>>();
        capacities = new int[vertices, vertices];
        for (int i = 0; i < vertices; i++)
        {
            adj.Add(new List<int>());
            var values = lines[i + 1].Split(' ');
            for (int j = 0; j < vertices; j++)
            {
                int capacity = int.Parse(values[j]);
                if (capacity > 0)
                {
                    adj[i].Add(j);
                    capacities[i, j] = capacity;
                }
            }
        }
        Console.WriteLine($"Graph initialised with {vertices} vertices.");
        Console.WriteLine($"Adjacency list has {adj.Count} elements.");
    }

    public void ReadMST(string mst)
    {
        var lines = File.ReadAllLines(mst);
        vertices = int.Parse(lines[0]);
        adj = new List<List<int>>();    
        weights = new int[vertices, vertices];

        for (int i = 0; i < vertices; i++)
        {
            adj.Add(new List<int>());
            var values = lines[i + 1].Split(' ');
            for (int j = 0; j < vertices; j++)
            {
                int weight = int.Parse(values[j]);
                weights[i, j] = weight;
                if (weight > 0)
                {
                    adj[i].Add(j);
                }
            }
        }
        Console.WriteLine($"Graph initialised with {vertices} vertices.");
        Console.WriteLine($"Adjacency list has {adj.Count} elements.");
    }

    public void PrintEdges()
    {
        for (int i = 0; i < vertices; ++i)
        {
            foreach(int j in adj[i])
                Console.WriteLine($"{i} -> {j}");
        }
    }

    public void PrintAdjacencies()
    {
        for (int i = 0; i < vertices; i++)
        {
            Console.Write($"{i}: ");
            Console.WriteLine(string.Join(" ", adj[i]));
        }
    }
    
}