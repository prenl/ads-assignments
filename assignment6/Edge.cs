namespace assignment6;

public class Edge<V>
{
    private Vertex<V> _source;
    private Vertex<V> _dest;
    private double _weight;

    public Edge(Vertex<V> source, Vertex<V> dest, double weight)
    {
        _source = source;
        _dest = dest;
        _weight = weight;
    }

    public Edge(Vertex<V> source, Vertex<V> dest)
    {
        _source = source;
        _dest = dest;
    }

    public Vertex<V> getSource()
    {
        return _source;
    }

    public Vertex<V> getDest()
    {
        return _dest;
    }

    public double getWeight()
    {
        return _weight;
    }

    public void setDest(Vertex<V> dest)
    {
        _dest = dest;
    }

    public void setSource(Vertex<V> source)
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

        Edge<V> edge = (Edge<V>)obj;
        return _source.Equals(edge._source) && _dest.Equals(edge._dest);
    }
}
