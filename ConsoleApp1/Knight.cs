using System;


namespace ConsoleApp1
{

    public class Knight
    {
        public int nPositions;
        public int nSteps;
        public int[] movementsX = { 2, 1, -1, -2, -2, -1, 1, 2 };
        public int[] movementsY = { 1, 2, 2, 1, -1, -2, -2, -1 };
        public int iterations = 0;
        public int[,] table;

        public Knight(int tableSize)
        {
            this.nPositions = tableSize;
            this.nSteps = tableSize * tableSize;
            this.table = new int[tableSize,tableSize];   
        }

        private Boolean CanAcceptMove(int x, int y)
        {
            Boolean result = (x >= 0 && x <= nPositions - 1);
            result = result && (y >= 0 && y <= nPositions­ - 1);
            result = result && (table[x,y] == 0);
            return result;
        }

        private Boolean TryMove(int i, int x, int y)
        {
            Boolean done = (i > nSteps);
            int k = 0;
            int u, v;
            
            while(!done && k < 8)
            {
                u = x + movementsX[k];
                v = y + movementsY[k];
                if (CanAcceptMove(u, v))
                {
                    table[u, v] = i;
                    done = TryMove(i + 1, u, v);
                    if (!done)
                    {
                        table[u,v] = 0;
                    }
                }
                iterations++;
                k++;
                
            }
            return done;
        }

        public void RevealTheMagic(int x, int y)
        {
            
            table[x, y] = 1;
            Boolean done = TryMove(2, x, y);
            if (done)
            {
                for(int i = 0; i< nPositions; i++)
                {
                    for ( int j = 0 ; j < nPositions; j++)
                    {
                        Console.Write(table[i,j] );
                        Console.Write(" ");
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar um caminho");
            }
            
        }
    }
}
