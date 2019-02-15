using System;
using System.Collections.Generic;
using System.Text;

namespace SemRecursividade
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool AlreadyVisited { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            AlreadyVisited = false;
        }
    }
}
