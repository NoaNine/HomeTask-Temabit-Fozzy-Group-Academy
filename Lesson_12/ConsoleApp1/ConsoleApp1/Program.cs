using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        public static void Print_X(int r)
        {
            int x = 0;
            int y = 0;
            while (x <= r)
            {
                while (y <= r)
                {
                    if (x == y || y == r - x)
                        Console.Write("*");
                    else
                        Console.Write(".");
                    y++;
                }
                y = 0;
                Console.WriteLine();
                x++;
            }
            Console.WriteLine();
        }
        public static void Print_Z(int r)
        {
            int x = 0;
            int y = 0;
            while (x <= r)
            {
                while (y <= r)
                {
                    if (x == 0 || y == r - x || x == r)
                        Console.Write("*");
                    else
                        Console.Write(".");
                    y++;
                }
                y = 0;
                Console.WriteLine();
                x++;
            }
            Console.WriteLine();
        }
        public static void Print_N(int r)
        {
            int x = 0;
            int y = 0;
            while (x <= r)
            {
                while (y <= r)
                {
                    if (y == 0 || x == y || y == r)
                        Console.Write("*");
                    else
                        Console.Write(".");
                    y++;
                }
                y = 0;
                Console.WriteLine();
                x++;
            }
            Console.WriteLine();
        }
        static int Row, Col;
        static void Main(string[] args)
        {
            int radius = 20;
            Print_N(radius);
            Print_X(radius);
            Print_Z(radius);
            for (Row = 0; Row < 7; Row++)
            {
                for (Col = 0; Col < 7; Col++)
                {
                    if (((Col == 1 || Col == 5) && Row != 0) || ((Row == 0 || Row == 3) && (Col > 1 && Col < 5)))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
