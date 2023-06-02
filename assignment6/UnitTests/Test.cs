using assignment6.Search;
using NUnit.Framework;
using System.Net;

namespace assignment6.UnitTests;

[TestFixture]
public class GraphTests
{
    private WeightedGraph<string> graph;
    private BreadthFirstSearch<string> bfs;
    private DepthFirstSearch<string> dfs;
    private DijkstraSearch<string> ds;

    [Test]
    public void GraphTest()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Astana", "Shymkent", 3.9);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Almaty", "Kyzylorda", 27);

        Assert.AreEqual(graph.GetEdgesCount(), 5);
        Assert.AreEqual(graph.GetEdges("Almaty").Count(), 3);
        Assert.AreEqual(graph.GetEdges("Astana").Count(), 2);
        Assert.AreEqual(graph.GetEdges("Kyzylorda").Count(), 2);
    }

    // Breadth First Search UnitTests

    [Test]
    public void BFSTest1()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Astana", "Kostanay", 3.5);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        BreadthFirstSearch<string> bfs = new BreadthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(bfs.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Shymkent", "Almaty" }));
    }

    [Test]
    public void BFSTest2()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Almaty", "Kyzylorda", 27);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        BreadthFirstSearch<string> bfs = new BreadthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(bfs.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Almaty" }));
    }

    [Test]
    public void BFSTest3()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Petropavl", "Astana", 4.2);
        graph.AddEdge("Astana", "Karagandy", 1.5);
        graph.AddEdge("Karagandy", "Balhash", 10.1);
        graph.AddEdge("Balhash", "Almaty", 7.0);
        graph.AddEdge("Petropavl", "Almaty", 54); // You can see that this is the most worse way

        BreadthFirstSearch<string> bfs = new BreadthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(bfs.GetPathTo("Petropavl").SequenceEqual(new[] { "Petropavl", "Almaty" }));
    }

    // Depth First Search UnitTests

    [Test]
    public void DFSTest1()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Astana", "Kostanay", 3.5);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        DepthFirstSearch<string> dfs = new DepthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(dfs.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Shymkent", "Astana", "Almaty" }));
    }

    [Test]
    public void DFSTest2()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Almaty", "Kyzylorda", 27);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        DepthFirstSearch<string> dfs = new DepthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(dfs.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Shymkent", "Astana", "Almaty" }));
    }

    [Test]
    public void DFSTest3()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Petropavl", "Astana", 4.2);
        graph.AddEdge("Astana", "Karagandy", 1.5);
        graph.AddEdge("Karagandy", "Balhash", 10.1);
        graph.AddEdge("Balhash", "Almaty", 7.0);
        graph.AddEdge("Petropavl", "Almaty", 54); // You can see that this is the most worse way

        DepthFirstSearch<string> dfs = new DepthFirstSearch<string>(graph, "Almaty");

        Assert.IsTrue(dfs.GetPathTo("Petropavl").SequenceEqual(new[] { "Petropavl", "Astana", "Karagandy", "Balhash", "Almaty" }));
    }

    // Dijkstra Search UnitTests

    [Test]
    public void DSTest1()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Astana", "Kostanay", 3.5);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        DijkstraSearch<string> ds = new DijkstraSearch<string>(graph, "Almaty");

        Assert.IsTrue(ds.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Shymkent", "Astana", "Almaty" }));
    }

    [Test]
    public void DSTest2()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Almaty", "Astana", 2.1);
        graph.AddEdge("Almaty", "Shymkent", 7.2);
        graph.AddEdge("Shymkent", "Astana", 3.9);
        graph.AddEdge("Almaty", "Kyzylorda", 2);
        graph.AddEdge("Shymkent", "Kyzylorda", 5.4);

        DijkstraSearch<string> ds = new DijkstraSearch<string>(graph, "Almaty");

        Assert.IsTrue(ds.GetPathTo("Kyzylorda").SequenceEqual(new[] { "Kyzylorda", "Almaty" }));
    }

    [Test]
    public void DSTest3()
    {
        graph = new WeightedGraph<string>(true);

        graph.AddEdge("Petropavl", "Astana", 4.2);
        graph.AddEdge("Astana", "Karagandy", 1.5);
        graph.AddEdge("Petropavl", "Semey", 20);
        graph.AddEdge("Semey", "Almaty", 10);
        graph.AddEdge("Karagandy", "Balhash", 10.1);
        graph.AddEdge("Balhash", "Almaty", 7.0);

        DijkstraSearch<string> ds = new DijkstraSearch<string>(graph, "Almaty");

        Assert.IsTrue(ds.GetPathTo("Petropavl").SequenceEqual(new[] { "Petropavl", "Astana", "Karagandy", "Balhash", "Almaty" }));
    }

}