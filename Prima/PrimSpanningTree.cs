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
            GetPoints();
        }

        public void Prim()
        {
            int countPoints = NotUsedPoints.Count;

            for (int i = 0; i < countPoints; ++i)
                NotUsedPoints.Add(i);

            Random rnd = new Random();
            UsedPoints.Add(rnd.Next(0, countPoints));
            NotUsedPoints.RemoveAt(UsedPoints[0]);

            while (NotUsedPoints.Count > 0)
            {
                int minEdge = -1;
                for (int i = 0; i < NotUsedEdges.Count; ++i)
                {
                    if ((UsedPoints.IndexOf(NotUsedEdges[i].Point1) != -1) && (NotUsedPoints.IndexOf(NotUsedEdges[i].Point2) != -1) ||
                (UsedPoints.IndexOf(NotUsedEdges[i].Point2) != -1) && (NotUsedPoints.IndexOf(NotUsedEdges[i].Point1) != -1))
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

                if (UsedPoints.IndexOf(NotUsedEdges[minEdge].Point1) != -1)
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

        private void GetPoints()
        {
            for(int i = 0; i < NotUsedEdges.Capacity; ++i)
            {
                if(NotUsedPoints == null || !NotUsedPoints.Contains(NotUsedEdges[i].Point1))
                {
                    NotUsedPoints.Add(NotUsedEdges[i].Point1);
                }
                if (NotUsedPoints == null || !NotUsedPoints.Contains(NotUsedEdges[i].Point2))
                {
                    NotUsedPoints.Add(NotUsedEdges[i].Point2);
                }
            }
        }
    }
}
