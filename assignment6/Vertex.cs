namespace assignment6;

public class Vertex<V>
{

    private V Data;
    private Dictionary<Vertex<V>, double> AdjacentVertices;

    public Vertex(V data) {
        Data = data;
        AdjacentVertices = new Dictionary<Vertex<V>, double>();
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
                if(vertex.Data.Equals(v.Data))
                {
                    AdjacentVertices.Remove(v);
                }
            }
        }
    }



}
