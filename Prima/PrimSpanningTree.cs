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
