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
        double d = Distances[dest];
        return (d == null) ? double.MaxValue : d;
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
        Vertex? min = default;

        foreach (Vertex v in vertices) 
        {
            if (min == null)
            {
                min = v;
            } 
            else
            {
                if (GetShortestDistance(v) <  GetShortestDistance(min))
                {
                    min = v;
                }
            }
        }

        return min;
    }

    private void Dijkstra()
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
                if (GetShortestDistance(v) > GetShortestDistance(node) + GetDistance(node, v))
                {
                    Distances.Add(v, GetShortestDistance(node) + GetDistance(node, v));
                    EdgeTo.Add(v, node);
                    UnsettledNodes.Add(v);
                }
            }
        }
    }

}
