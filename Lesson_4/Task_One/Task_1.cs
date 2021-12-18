using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_One
{
    class Task_1
    {
        static void Main(string[] args)
        {
            char print = '*';
            byte j = 0;
            sbyte[] array = new sbyte[6] { 3, -5, 2, 1, 8, 9 };
            foreach (sbyte i in array)
            {
                if (i >= 0)
                    while (j < i)
                    {
                        Console.Write(print);
                        j++;
                    }
                else
                    Console.Write("Отрицательное или неверное число");
                j = 0;
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
