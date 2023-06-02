using assignment6.Search;

namespace assignment6;

public class Program
{
    
    public static void Main(string[] args)
    {
        WeightedGraph<string> graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Almaty", "Kyzylorda", 27);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        DijkstraSearch<string> search = new DijkstraSearch<string>(graph, "Almaty");
        
        foreach(var item in search.GetPathTo("Kyzylorda")) {
            Console.Write(item + " <--> ");
        }
    }

}