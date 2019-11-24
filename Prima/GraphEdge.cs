using System;
using System.Collections.Generic;
using System.Text;

namespace Prima
{
    class GraphEdge
    {
        public int Point1 { get; } = 0;
        public int Point2 { get; } = 0;
        public int Weight { get; set; } = 0;

        public GraphEdge(int p1, int p2, int weight)
        {
            Point1 = p1;
            Point2 = p2;
            Weight = weight;
        }
    }
}
