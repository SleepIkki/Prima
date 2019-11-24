using System;
using System.Collections.Generic;

namespace Prima
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GraphEdge> graph = new List<GraphEdge>()
            {
                new GraphEdge(1,3,6),
                new GraphEdge(1,6,8),
                new GraphEdge(1,4,7),
                new GraphEdge(2,3,1),
                new GraphEdge(2,4,3),
                new GraphEdge(2,6,2),
                new GraphEdge(2,7,4),
                new GraphEdge(3,8,7),
                new GraphEdge(4,5,9),
                new GraphEdge(5,7,5),
                new GraphEdge(6,8,3),
                new GraphEdge(7,8,4)
            };
            PrimSpanningTree primTree = new PrimSpanningTree(graph);
            primTree.Prim();
            Console.WriteLine(primTree.ToString());
        }
    }
}
