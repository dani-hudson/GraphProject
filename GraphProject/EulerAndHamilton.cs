namespace GraphProject;

// You can either modify it or use it as your own
// If you got any cooler implementaions, please email me at dan@tsukishiro.eu
// I would love to hear your thoughts and idea about these.

public partial class Graph
{
    public bool IsEuler()
    {
        if (!IsUndirected())
            return false;

        return adj.All(list => list.Count % 2 == 0);
    }

    public void EulerCircuits()
    {
        if (!IsEuler())
        {
            Console.WriteLine("Graph is not Eulerian!");
            return;
        }

        var circuits = new List<int>();
        var stack = new Stack<int>();
        var current = 0; // start at vertex 0 
        
        stack.Push(current);
        while (stack.Count > 0)
        {
            if (adj[current].Count == 0)
            {
                circuits.Add(current);
                current = stack.Pop();
            }
            else
            {
                stack.Push(current);
                int next = adj[current][0];
                adj[current].RemoveAt(0);
                adj[next].Remove(current);
                current = next;
            }
        }
        
        Console.WriteLine("Euler Circuits: " + string.Join("->", circuits));
    }

    // I would not consider using these
    // Hamiltonian is so fucking complex that if the graph gets larger, it just gonna be to heavy for a computer to solve
    // if you got any suggestion, please email me at dan@tsukishiro.eu, I would love to see your ideas about it
    private bool HamiltonianUtility(List<int> path, bool[] visited, int pos)
    {
        if (pos == vertices)
        {
            return adj[path[pos - 1]].Contains(0);
        }

        for (int v = 1; v < vertices; v++)
        {
            if (IsSafe(v, path, pos, visited))
            {
                visited[v] = true;
                path.Add(v);

                if (HamiltonianUtility(path, visited, pos + 1))
                    return true;

                visited[v] = false;
                path.RemoveAt(path.Count - 1);
            }
        }

        return false;
    }

    private bool IsSafe(int v, List<int> path, int pos, bool[] visited)
    {
        if (!adj[path[pos - 1]].Contains(v))
            return false;

        if (visited[v])
            return false;

        return true;
    }
    
    
    public void Hamiltonian()
    {
        var visited = new bool[vertices];
        var path = new List<int>();
        path.Add(0);
        
        if (HamiltonianUtility(path, visited, 1))
        {
            Console.WriteLine("Hamiltonian Circuit: " + string.Join(" -> ", path) + " -> 0");
        }
        else
        {
            Console.WriteLine("No Hamiltonian Circuit exists");
        }
    }
}