using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int x,y, n = 8;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Posição X");
            input = Console.ReadLine();
            Int32.TryParse(input, out x);

            Console.WriteLine("Posição Y");
            input = Console.ReadLine();
            Int32.TryParse(input, out y);

            Knight knight = new Knight(n);
            Console.WriteLine("Calculando..");
            knight.RevealTheMagic(x, y);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("iterations: " + knight.iterations);
            // wait for input to close console
            Console.ReadLine();
        }
    }
}
