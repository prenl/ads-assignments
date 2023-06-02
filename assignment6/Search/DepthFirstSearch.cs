using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6.Search;

public class DepthFirstSearch<Vertex> : Search<Vertex>
{

    public DepthFirstSearch(WeightedGraph<Vertex> graph, Vertex source) : base(source)
    {
        dfs(graph, source);
    }

    private void dfs(WeightedGraph<Vertex> graph, Vertex source)
    {
        Marked.Add(source);
        Count++;

        foreach(Vertex v in graph.AdjacencyList(source))
        {
            if (!Marked.Contains(v))
            {
                EdgeTo.Add(v, source);
                dfs(graph, v);
            }
        }
    }

}
