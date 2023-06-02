namespace assignment6.Search;

public class BreadthFirstSearch<Vertex> : Search<Vertex>
{

    public BreadthFirstSearch(WeightedGraph<Vertex> graph, Vertex source) : base(source)
    {
        bfs(graph, source);
    }

    private void bfs(WeightedGraph<Vertex> graph, Vertex source)
    {
        Marked.Add(source);
        LinkedList<Vertex> queue = new LinkedList<Vertex>();
        queue.AddLast(source);

        while (queue.Count != 0)
        {
            Vertex v = queue.First.Value;
            queue.RemoveFirst();

            foreach (Vertex vertex in graph.AdjacencyList(v))
            {
                if (!Marked.Contains(vertex))
                {
                    Marked.Add(vertex);
                    EdgeTo.Add(vertex, v);
                    queue.AddLast(vertex);
                }
            }
        }
    }

}
