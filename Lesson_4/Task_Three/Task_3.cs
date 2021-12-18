using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Three
{
    class Task_3
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 6;
            int[][] jagged = new int[n][];
            int rage = 100;
            int min = rage;
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[rnd.Next(5, 10)]; 
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = rnd.Next(rage);
                    Console.Write(jagged[i][j] + "\t");
                }
                Console.WriteLine();
            }
            for (int i = 1; i < jagged.Length; i+=2)
            {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        if ((jagged[i][j] & 1) == 1 && jagged[i][j] < min)
                            min = jagged[i][j];
                    }
            }
            Console.WriteLine("Минимальное число среди нечетных значений и в четных строках " + min);
            byte e = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if ((jagged[i][j] % 8) == 0 && jagged[i][j] != 0)
                    {
                        Console.Write(jagged[i][j] + " ");
                        e++;
                    }
                }
            }
            Console.WriteLine("Количество значений делимых на 8 без остатка: " + e);
            Console.Write("Первые 4 значения которые делятся на 7: ");
            byte f = 0;
            for (int i = 0; i < jagged.Length; i++) // как сделать теперь тоже самое только последние 3 значения, 
            {                                          // через доп переменную которая посчитает длинну всего массива или есть команда
                for (int j = 0; j < jagged[i].Length; j++)  // на ход с конца, а не по порядку??
                {
                    if ((jagged[i][j] % 7) == 0 && f <= 4 && jagged[i][j] != 0)
                    {
                        Console.Write(jagged[i][j] + " ");
                        f++;
                    }
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }

}
