namespace GraphProject;

public partial class Graph
{
    private int vertices; // vertices
    private List<List<int>> adj; // adjacency
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
        for (int i = 0; i < vertices; i++)
        {
            adj.Add(new List<int>());
            var values = lines[i + 1].Split(' ');
            for (int j = 0; j < vertices; j++)
            {
                if (int.Parse(values[j]) == 1)
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