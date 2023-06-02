# Assignment-6 of ADS course (The last one)
# ASTANA IT UNIVERSITY
### SE-2203, Abdrakhmanov Yelnur 🇰🇿

#

### Graph's classes

#

`Vertex<V> class`
- `Vertex(V data)` - constructor, put data in Vertex
- `GetData()` - object, show data in Vertex
- `AddAdjacentVertex(V vertex, double weight)` - void, add way to another vertex + way's weight
- `DeleteAdjacentVertex(V vertex)` - void, remove way from vertex

#

`Edge<Vertex>` class
- `Edge(Vertex source, Vertex dest, double weight)` - constructor, put source dest and weight of edge
- `Edge(Vertex source, Vertex dest)` - constructor, put source dest with `double.MaxValue` weight
- `Equals(object? obj)` - bool, overrided method, compares two edges
- `ToString()` - string, overrided method, return edge in string
- Getters and Setters for source, dest and weight

#

`WeightedGraph<Vertex>` class
- `WeightedGraph()` - constructor, create undirected graph
- `WeightedGraph(bool undirected)` - constructor, create graph with specified direction
- `HasVertex(Vertex vertex)` - bool, check if vertex is in the graph
- `HasEdge(Vertex source, Vertex dest)` - bool, check if edge is in the graph
- `AddVertex(Vertex v)` - void, add vertex to the graph
- `AddEdge(Vertex source, Vertex dest, double weight)` - void, add edge to the graph
- `GetVerticesCount()` - int, return number of vertex in the graph
- `GetEdgesCount()` - int, sums number of edges in each vertex
- `AdjacencyList(Vertex v)` - `IEnumerable<Vertex>`, iterator on edges for vertex
  
#
  
### Search classes

#
  
┌ `BreadthFirstSearch class` - visits all adjacent vertices at each level before proceeding to the next, providing a search in width. <br/>
├ `DepthFirstSearch class` - visits one vertex, then recursively goes deep into each vertex until the end, providing a search in depth. <br/>
├ `DijkstraSearch class` - iteratively goes through all the paths in search of the "easiest" way by the weight of each edge. <br/>
│ <br/>
└ HAVE THE SAME METHODS <br/>

- `AlgorithmName(WeightedGraph<Vertex>, Vertex source)` - constructor, creates and executes chosen search algoritm
- `HasPathTo(Vertex v)` - bool, check if source Vertex has way to specified destination 
- `GetPathTo(Vertex v)` - `IEnumerable<Vertex>`, creates list -> way to specified destination
- `GetCount()` - int, return number of vertices on the way to destination

#

### UnitTests

#

GraphTests class
- 3 BFS Tests
- 3 DFS Tests
- 3 Dijkstra Tests
- 1 Weighted Graph filling test

#

Assignment was done on `C# (.net 7.0)`, using `Microsoft Visual Studio 2023`
