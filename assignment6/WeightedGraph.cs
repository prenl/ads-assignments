namespace assignment6;

public class WeightedGraph<Vertex>
{
    private readonly bool _undirected;
    private Dictionary<Vertex, List<Edge<Vertex>>> _map = new Dictionary<Vertex, List<Edge<Vertex>>>();

    public WeightedGraph()
    {
        _undirected = true;
    }

    public WeightedGraph(bool undirected)
    {
        _undirected = undirected;
    }

    public bool HasVertex(Vertex vertex)
    {
        return _map.ContainsKey(vertex);
    }

    public bool HasEdge(Vertex source, Vertex dest)
    {
        if (!HasVertex(source)) return false;
        return _map[source].Contains(new Edge<Vertex>(source, dest));
    }

    public void AddVertex(Vertex v)
    {
        _map.Add(v, new List<Edge<Vertex>>());
    }

    public void AddEdge(Vertex source, Vertex dest, double weight)
    {
        if (!HasVertex(source)) AddVertex(source);
        if (!HasVertex(dest)) AddVertex(dest);

        if (HasEdge(source, dest) || source.Equals(dest)) return;

        _map[source].Add(new Edge<Vertex>(source, dest, weight));

        if (_undirected) 
            _map[dest].Add(new Edge<Vertex>(dest, source, weight));
    }

    public int GetVerticesCount()
    {
        return _map.Count;
    }

    public int GetEdgesCount()
    {
        int counter = 0;
        
        foreach(var v in _map.Keys)
        {
            counter += _map[v].Count;
        }

        if (_undirected)
            counter /= 2;

        return counter;
    }

    public IEnumerable<Vertex> AdjacencyList(Vertex v)
    {
        if (!HasVertex(v)) yield break;

        foreach(var edge in _map[v]) {
            yield return edge.GetDest();
        }
    }

    public IEnumerable<Edge<Vertex>> GetEdges(Vertex v) 
    { 
        if (!HasVertex(v)) return null;
        return _map[v];
    }

}
