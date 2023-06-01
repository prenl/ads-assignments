namespace assignment6;

public class Vertex<V>
{

    private V _data;
    private Dictionary<Vertex<V>, double> AdjacentVertices;

    public Vertex(V data) {
        _data = data;
        AdjacentVertices = new Dictionary<Vertex<V>, double>();
    }

    public V GetData()
    {
        return _data;
    }

    public void AddAdjacentVertex(Vertex<V> vertex, double weight)
    {
        AdjacentVertices.Add(vertex, weight);
    }

    public void DeleteAdjacentVertex(Vertex<V> vertex) 
    {
        bool delete = AdjacentVertices.Remove(vertex);

        if (!delete)
        {
            foreach(var v in AdjacentVertices.Keys)
            {
                if(vertex._data.Equals(v._data))
                {
                    AdjacentVertices.Remove(v);
                }
            }
        }
    }

}
