namespace assignment6.Search;

public class DijkstraSearch<Vertex> : Search<Vertex>
{

    private HashSet<Vertex> UnsettledNodes;
    private Dictionary<Vertex, double> Distances;
    private WeightedGraph<Vertex> Graph;

    public DijkstraSearch(WeightedGraph<Vertex> graph, Vertex source) : base(source)
    {
        UnsettledNodes = new HashSet<Vertex>();
        Distances = new Dictionary<Vertex, double>();
        Graph = graph;
        Dijkstra();
    }

    private double GetShortestDistance(Vertex dest)
    {
        if (Distances.TryGetValue(dest, out double d))
            return d;

        return double.MaxValue;
    }

    private double GetDistance(Vertex from, Vertex to)
    {
        foreach (Edge<Vertex> edge in Graph.GetEdges(from))
        {
            if (edge.GetDest().Equals(to))
            {
                return edge.GetWeight();
            }
        }

        throw new Exception("Target vertex not found!");
    }

    private Vertex GetVertexWithMinimumWeight(HashSet<Vertex> vertices)
    {
        Vertex min = default;
        foreach (Vertex v in vertices)
        {
            if (min == null || GetShortestDistance(v) < GetShortestDistance(min))
            {
                min = v;
            }
        }

        return min;
    }

    public void Dijkstra()
    {
        Distances.Add(Source, 0);
        UnsettledNodes.Add(Source);

        while (UnsettledNodes.Count > 0)
        {
            Vertex node = GetVertexWithMinimumWeight(UnsettledNodes);
            Marked.Add(node);
            UnsettledNodes.Remove(node);

            foreach (Vertex v in Graph.AdjacencyList(node))
            {
                double newDistance = GetShortestDistance(node) + GetDistance(node, v);
                if (GetShortestDistance(v) > newDistance)
                {
                    Distances[v] = newDistance;
                    EdgeTo[v] = node;
                    UnsettledNodes.Add(v);
                }
            }
        }
    }

}
