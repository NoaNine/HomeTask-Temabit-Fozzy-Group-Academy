using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    class Additional
    {
        static void Main(string[] args)
        { // не работает перебор пузырьком двумерного масива, разобрать потом!
            Random rnd = new Random();
            int n = 6;
            int[][] jagged = new int[n][];
            int rage = 100;
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[rnd.Next(5, 10)];
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = rnd.Next(rage);
                }
            }
            int temp;
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length - 1; j++)

                    for (int k = j + 1; k < jagged.Length; k++)
                    {
                        if (jagged[i][j] > jagged[i][j + 1])
                        {
                            temp = jagged[i][j];
                            jagged[i][j] = jagged[i][j + 1];
                            jagged[i][j + 1] = temp;
                        }
                    }
            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
