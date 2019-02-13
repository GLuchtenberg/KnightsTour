using System;
using System.Collections.Generic;
using System.Text;

namespace warnsdorf
{
    class Warnsdorff
    {
        public int n;
        public int nTotal;
        public int[] table;
        public int[] movementsX = { 2, 1, -1, -2, -2, -1, 1, 2 };
        public int[] movementsY = { 1, 2, 2, 1, -1, -2, -2, -1 };
        public int iterations = 0;

        public Warnsdorff(int n)
        {
            this.n = n;
            nTotal = n * n;
            table = new int[nTotal];
            for(int i = 0; i < nTotal; i++)
            {
                table[i] = -1;
            }
            
        }


        /* displays the chessboard with all the 
          legal knight's moves */
        public void RevealTheMagic()
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(table[j * n + i] +" ");
                Console.WriteLine();
            }
        }


        public bool Run(int sx, int sy)
        {
            
            // Current points are same as initial points 
            int x = sx, y = sy;
            table[y * n + x] = 1; // Mark first move. 

            // Keep picking next points using 
            // Warnsdorff's heuristic 
            for (int i = 0; i < nTotal - 1; ++i)
                if (nextMove(a, &x, &y) == 0)
                    return false;

            // Check if tour is closed (Can end 
            // at starting point) 
            if (!neighbour(x, y, sx, sy))
                return false;

            print(a);
            return true;

        }
    }
}
