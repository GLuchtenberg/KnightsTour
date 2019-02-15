using System;
using System.Collections.Generic;
using System.Linq;

namespace SemRecursividade
{

    public class Knight
    {
        public int nPositions;
        public int currentPosition;
        public int[] movementsX = { 2, 1, -1, -2, -2, -1, 1, 2 };
        public int[] movementsY = { 1, 2, 2, 1, -1, -2, -2, -1 };
        public int iterations = 0;
        public int[,] table;

        public int ShouldJump = 0;

        public Knight(int tableSize)
        {
            currentPosition = 1;
            this.nPositions = tableSize;
            this.table = new int[tableSize,tableSize];   
        }

        public Move CheckDegree(Point point)
        {
            return CheckDegree(point.X, point.Y);
        }

        public Move CheckDegree(int xTable, int yTable)
        {
            var approvedMovements = new List<Point>();
            for (int i = 0; i < 8; i++)
            {
                int testPointX = xTable + movementsX[i], testPointY = yTable + movementsY[i];
                var canAcceptMove = CanAcceptMove( testPointX, testPointY);
                if (canAcceptMove)
                {
                    var point = new Point(testPointX , testPointY);
                    approvedMovements.Add(point);
                }
            }
            return new Move(new Point(xTable,yTable), approvedMovements);
        }

        public Boolean CanAcceptMove(int x, int y)
        {
            Boolean result = (x >= 0 && x <= nPositions - 1);
            result = result && (y >= 0 && y <= nPositions­ - 1);
            result = result && (table[x,y] == 0);
            return result;
        }

        public void Run(int x, int y)
        {
            // primeira checagem
            table[x, y] = currentPosition;
            //Move move = new List<Move>();

            //tenho dois movimentos
            Move move = CheckDegree(x, y);
            while (currentPosition < 64)
            {
                //move.Add(CheckDegree(x, y));

                var moves = new List<Move>();
                foreach (var point in move.Points)
                {
                    moves.Add(CheckDegree(point.X, point.Y));
                }
                moves = moves.OrderBy(m => m.Cost).ToList();
                
                move = moves.ElementAt(ShouldJump);
                table[move.Point.X, move.Point.Y] = ++currentPosition;
            }

            for (int i = 0; i < nPositions; i++)
            {
                for (int j = 0; j < nPositions; j++)
                {
                    Console.Write(table[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

    }
}
