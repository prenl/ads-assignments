namespace assignment6.Search;

public abstract class Search<Vertex>
{

    protected int Count;
    protected HashSet<Vertex> Marked;
    protected Dictionary<Vertex, Vertex> EdgeTo;
    protected readonly Vertex Source;

    public Search(Vertex s)
    {
        Source = s;
        Marked = new HashSet<Vertex>();
        EdgeTo = new Dictionary<Vertex, Vertex>();
    }

    public bool HasPathTo(Vertex vertex)
    {
        return Marked.Contains(vertex);
    }

    public IEnumerable<Vertex> GetPathTo(Vertex vertex)
    {
        if (!HasPathTo(vertex)) return null;

        LinkedList<Vertex> list = new LinkedList<Vertex>();

        for(Vertex v = vertex; !v.Equals(Source); v = EdgeTo[v])
            list.AddLast(v);

        list.AddLast(Source);

        return list;
    }

    public int GetCount()
    {
        return Count;
    }

}
