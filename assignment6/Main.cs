namespace assignment6;

public class Program
{
    
    public static void Main(string[] args)
    {
        WeightedGraph<string> graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Astana", "Kostanay", 3.5);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        foreach(var ver in graph.getEdges("Almaty"))
        {
            Console.WriteLine(ver);
        }

    }

}