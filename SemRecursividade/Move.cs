using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemRecursividade
{
    public class Move
    {
        public List<Point> Points { get; set; }
        public int Cost { get; set; }
        public Point Point { get; set; }
        public Move(Point point, List<Point> points)
        {
            Point = point;
            Points = points;
            Cost = points.Count();
        }
    }
}
