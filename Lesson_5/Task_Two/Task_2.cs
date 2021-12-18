using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Two
{
    class Task_2
    {
        public static void FillingArray(int[] anArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < anArray.Length; i++)
            {
                anArray[i] = rnd.Next(-100, 100);
            }
        }
        public static void Print(int[] anArray)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                Console.Write(anArray[i] + "\t");
            }
            Console.WriteLine();
        }
        public static void Swap(ref int one, ref int two)
        {
            int temp;
            temp = one;
            one = two;
            two = temp;
        }
        public static void BubbleSort(int[] anArray)
        {
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                for (int j = i + 1; j < anArray.Length; j++)
                {
                    if (anArray[i] > 0)
                        Swap(ref anArray[i], ref anArray[j]);
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[15];
            FillingArray(array);
            Console.WriteLine("Исходный массив выглядит так");
            Print(array);
            Console.WriteLine("Отсортированный массив выглядит так");
            BubbleSort(array);
            Print(array);
            Console.ReadKey();
        }
    }
}
