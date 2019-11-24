using System;
using System.Collections.Generic;
using System.Text;

namespace Prima
{
    class PrimSpanningTree
    {
        public List<GraphEdge> NotUsedEdges { get; } = new List<GraphEdge>();
        public List<GraphEdge> SpanningTree { get; } = new List<GraphEdge>();
        List<int> UsedPoints = new List<int>();
        List<int> NotUsedPoints = new List<int>();

        public PrimSpanningTree(List<GraphEdge> graph)
        {
            NotUsedEdges = graph;
            NotUsedPoints = GetPoints(graph);
        }

        public void Prim()
        {
            Random rnd = new Random();
            UsedPoints.Add(rnd.Next(0, NotUsedPoints.Count - 1));
            NotUsedPoints.RemoveAt(UsedPoints[0]);

            while (NotUsedPoints.Count > 0)
            {
                int minEdge = -1;
                for (int i = 0; i < NotUsedEdges.Count; ++i)
                {
                    if ((UsedPoints.Contains(NotUsedEdges[i].Point1) && !UsedPoints.Contains(NotUsedEdges[i].Point2)) ||
                (UsedPoints.Contains(NotUsedEdges[i].Point2) && !UsedPoints.Contains(NotUsedEdges[i].Point1)))
                    {
                        if (minEdge != -1)
                        {
                            if (NotUsedEdges[i].Weight < NotUsedEdges[minEdge].Weight)
                                minEdge = i;
                        }
                        else
                            minEdge = i;
                    }
                }

                if (minEdge == -1) break;

                if (UsedPoints.Contains(NotUsedEdges[minEdge].Point1))
                {
                    UsedPoints.Add(NotUsedEdges[minEdge].Point2);
                    NotUsedPoints.Remove(NotUsedEdges[minEdge].Point2);
                }
                else
                {
                    UsedPoints.Add(NotUsedEdges[minEdge].Point1);
                    NotUsedPoints.Remove(NotUsedEdges[minEdge].Point1);
                }

                SpanningTree.Add(NotUsedEdges[minEdge]);
                NotUsedEdges.RemoveAt(minEdge);
            }
        }

        public List<int> GetPoints(List<GraphEdge> graph)
        {
            List<int> points = new List<int>();

            for(int i = 0; i < graph.Count; ++i)
            {
                if (points == null || !points.Contains(graph[i].Point1))
                    points.Add(graph[i].Point1);
                if (points == null || !points.Contains(graph[i].Point2))
                    points.Add(graph[i].Point2);
            }

            return points;
        }

        public override string ToString()
        {
            string spanningTree = "";
            for (int i = 0; i < SpanningTree.Count; ++i)
                spanningTree += ("Point1: " + SpanningTree[i].Point1 +
                    "\tPoint2: " + SpanningTree[i].Point2 + 
                    "\tWeight: " + SpanningTree[i].Weight) + "\n";
            return spanningTree;
        }
    }
}
