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
        if (graph.IsBipartite())
            Console.WriteLine("Graph is bipartite");

        graph.DFS(0);
        graph.BFS(0);
        Console.WriteLine();
        var connectedComps = graph.ConnectedComponents(); // ?? what
        Console.WriteLine();
        Console.WriteLine();

        var dijkstra = new Graph();
        CreateDijkstraGraphFile("dijkstra.txt");
        dijkstra.ReadMST("dijkstra.txt");


        dijkstra.Dijkstra(0);
        dijkstra.BellmanFord(0);
        //graph.PrintConnectedComponents(); // i mean yeah but why do we have to do this like twice?

        //CreateEulerianGraphFile("euler.txt");
        //Graph euler = new Graph();
        //graph.ReadPath("euler.txt");
        //graph.EulerCircuits();
        CreateMSTGraphFile("mst.txt");
        graph.ReadMST("mst.txt");

        graph.Prim(0);
        graph.Kruskal();
        var fulkerson = new Graph();
        //CreateFulkersonGraphFile("fulkerson.txt");
        fulkerson.ReadPath("fulkerson.txt");
        fulkerson.Fulkerson();
    }

    // These will create an .txt file, make sure that the path you're using got the right permission to read and write.
    static void CreateSampleGraphFile(string filename)
    {
        string[] lines =
        {
                "10",
                "0 1 1 1 0 0 0 0 0 0",
                "0 0 0 0 1 1 0 0 0 0",
                "0 0 0 0 0 1 1 0 0 0",
                "0 0 0 0 1 0 0 1 0 0",
                "0 0 0 0 0 0 0 1 1 0",
                "0 0 0 0 0 0 1 0 1 0",
                "0 0 0 0 0 0 0 1 0 1",
                "0 0 0 0 0 0 0 0 0 1",
                "0 0 0 0 0 0 0 0 0 1",
                "0 0 0 0 0 0 0 0 0 0"
        };
        File.WriteAllLines(filename, lines);
    }

    static void CreateFulkersonGraphFile(string filename)
    {
        string[] lines =
        {
            "6",
            "0 16 13 0 0 0",
            "0 0 10 12 0 0",
            "0 4 0 0 14 0",
            "0 0 9 0 0 20",
            "0 0 0 7 0 4",
            "0 0 0 0 0 0"
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

    static void CreateMSTGraphFile(string filename)
    {
        string[] lines = {
            "5",
            "0 2 0 6 0",
            "2 0 3 8 5",
            "0 3 0 0 7",
            "6 8 0 0 9",
            "0 5 7 9 0"

        };
        File.WriteAllLines(filename, lines);
        Console.WriteLine($"MST graph file created: {filename}");
    }

    static void CreateDijkstraGraphFile(string filename)
    {
        string[] lines = {
            "5",
            "0 4 0 6 6",
            "0 0 2 0 0",
            "4 0 0 8 0",
            "0 0 0 0 9",
            "0 0 0 0 0"
        };
        File.WriteAllLines(filename, lines);
    }
}
