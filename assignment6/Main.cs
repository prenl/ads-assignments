using assignment6.Search;

namespace assignment6;

public class Program
{
    
    public static void Main(string[] args)
    {
        WeightedGraph<string> graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Astana", "Shymkent", 3.9);
        graph.AddEdge("Almaty", "Kyzylorda", 27);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        BreadthFirstSearch<string> search = new BreadthFirstSearch<string>(graph, "Almaty");
        outputPath(search, "Shymkent");
        
    }

    public static void outputPath(Search<string> search, String key)
    {
        var list = search.GetPathTo(key);
        int i = 0;

        foreach (var item in list)
        {
            Console.Write(item);
            if (!(i == list.Count() - 1)) Console.Write(" <--> ");
            i++;
        }
    }

}