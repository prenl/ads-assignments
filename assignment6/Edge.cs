namespace assignment6;

public class Edge<Vertex>
{
    private Vertex<string> _source;
    private Vertex<string> _dest;
    private double _weight;

    public Edge(Vertex<string> source, Vertex<string> dest, double weight)
    {
        _source = source;
        _dest = dest;
        this._weight = weight;
    }

    public Vertex<string> getSource()
    {
        return _source;
    }

    public Vertex<string> getDest()
    {
        return _dest;
    }

    public double getWeight()
    {
        return _weight;
    }

    public void setDest(Vertex<string> dest)
    {
        _dest = dest;
    }

    public void setSource(Vertex<string> source)
    {
        _source = source;
    }

    public void setWeight(double weight)
    {
        _weight = weight;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (this == obj) return true;

        Edge<Vertex> edge = (Edge<Vertex>)obj;
        return _source.Equals(edge._source) && _dest.Equals(edge._dest);
    }
}
