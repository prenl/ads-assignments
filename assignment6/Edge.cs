namespace assignment6;

public class Edge<Vertex>
{
    private Vertex _source;
    private Vertex _dest;
    private double _weight;

    public Edge(Vertex source, Vertex dest, double weight)
    {
        _source = source;
        _dest = dest;
        _weight = weight;
    }

    public Edge(Vertex source, Vertex dest)
    {
        _source = source;
        _dest = dest;
    }

    public Vertex getSource()
    {
        return _source;
    }

    public Vertex getDest()
    {
        return _dest;
    }

    public double getWeight()
    {
        return _weight;
    }

    public void setDest(Vertex dest)
    {
        _dest = dest;
    }

    public void setSource(Vertex source)
    {
        _source = source;
    }

    public void setWeight(double weight)
    {
        _weight = weight;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        if (this == obj) return true;

        Edge<Vertex> edge = (Edge<Vertex>)obj;
        return _source.Equals(edge._source) && _dest.Equals(edge._dest);
    }

    public override string ToString()
    {
        return "Edge {source='" + _source + "', dest='" + _dest + "', weight=" + _weight + "}";
    }
}
