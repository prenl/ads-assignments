namespace assignment6;

public class Vertex<V>
{

    private V _data;
    private Dictionary<Vertex<V>, double> _adjacentVertices;

    public Vertex(V data) {
        _data = data;
        _adjacentVertices = new Dictionary<Vertex<V>, double>();
    }

    public V GetData()
    {
        return _data;
    }

    public void AddAdjacentVertex(Vertex<V> vertex, double weight)
    {
        _adjacentVertices.Add(vertex, weight);
    }

    public void DeleteAdjacentVertex(Vertex<V> vertex) 
    {
        bool delete = _adjacentVertices.Remove(vertex);

        if (!delete)
        {
            foreach(var v in _adjacentVertices.Keys)
            {
                if(vertex._data.Equals(v.GetData()))
                {
                    _adjacentVertices.Remove(v);
                }
            }
        }
    }

}
