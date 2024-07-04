namespace GraphProject;

class Program
{
    static void Main(string[] args)
    {
        CreateSampleGraphFile("path.txt");
        Graph graph = new Graph();
        graph.ReadPath("path.txt");
        
        graph.PrintEdges();
        Console.WriteLine();
        graph.PrintAdjacencies();

        if (graph.IsUndirected())
        {
            var totalDegree = graph.TotalDegree();
            var v1Deg = graph.Degree(1);
        }
        else
        {
            var totalOutDeg = graph.TotalOutDegree();
            var totalInDeg = graph.TotalInDegree();
            var x1 = graph.OutDegree(2);
            var x2 = graph.InDegree(2);
        }
        
        if (graph.IsComplete())
            Console.WriteLine("Graph is complete!");
        if (graph.IsCircular())
            Console.WriteLine("Graph is Circular!");
        if(graph.IsBipartite())
            Console.WriteLine("Graph is bipartite");

        graph.DFS(1);
        graph.BFS(1);
        Console.WriteLine();
        var connectedComps = graph.ConnectedComponents(); // ?? what
        //graph.PrintConnectedComponents(); // i mean yeah but why do we have to do this like twice?
        
        CreateEulerianGraphFile("euler.txt");
        Graph euler = new Graph();
        euler.ReadPath("euler.txt");
        euler.EulerCircuits();
        
        graph.Prim(1);
        graph.Kruskal();
        graph.Dijkstra(1);
        graph.BellmanFord(1);
        graph.Fulkerson();
    }

    static void CreateSampleGraphFile(string filename)
    {
        string[] lines =
        {
            "6",
            "0 1 1 0 0 0",
            "0 0 1 1 0 0",
            "0 0 0 1 1 0",
            "0 0 0 0 1 1",
            "0 0 0 0 0 1",
            "1 0 0 0 0 0"
        };
        File.WriteAllLines(filename, lines);
    }
    
    static void CreateEulerianGraphFile(string filename) // ignore this
    {
        string[] lines = {
            "6",
            "0 1 1 0 1 1",
            "1 0 1 1 1 0",
            "1 1 0 1 0 1",
            "0 1 1 0 1 1",
            "1 1 0 1 0 1",
            "1 0 1 1 1 0"
        };
        File.WriteAllLines(filename, lines);
        Console.WriteLine($"Eulerian graph file created: {filename}");
    }
}