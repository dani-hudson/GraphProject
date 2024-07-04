namespace GraphProject;

public partial class Graph
{
    public int ConnectedComponents()
    {
        var visited = new bool[vertices];
        int count = 0;
        for (int i = 0; i < vertices; ++i)
        {
            if (!visited[i])
            {
                DFSUtility(i, visited);
                count++;
            }
        }

        return count;
    }

    public void PrintConnectedComponents()
    {
        var visited = new bool[vertices];
        for (int i = 0; i < vertices; ++i)
        {
            if (!visited[i])
            {
                Console.WriteLine("Component(s): ");
                DFSUtility(i,visited);
                Console.WriteLine();
            }
        }
    }
    
}