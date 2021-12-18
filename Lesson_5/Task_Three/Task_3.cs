using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Three
{
    class Task_3
    {
        public static void ArrayOne(int[] oArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < oArray.Length; i++)
            {
                oArray[i] = rnd.Next(1, 10);
            }
        }
        public static void ArrayTwo(int[] tArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < tArray.Length; i++)
            {
                tArray[i] = rnd.Next(-10, -1);
            }
        }
        public static void Print(int[] pArray)
        {
            for (int i = 0; i < pArray.Length; i++)
            {
                Console.Write(pArray[i] + "\t");
            }
            Console.WriteLine();
        }
        public static void Insert( ref int[] arrayOne, ref int[]arrayTwo, int index )
        {
            int x = arrayOne.Length + arrayTwo.Length;
            int[] targetArray = new int[x];
            if (index <= arrayTwo.Length + 1)
                Array.Copy(arrayOne, 0, targetArray, index - 1, arrayOne.Length);
            else
            {
                Console.WriteLine("Индекс превышает размер масива куда идет вставка!");
                return;
            }
            int length = arrayOne.Length; 
            for (int i = 0; i < index-1; i++)
                targetArray[i] = arrayTwo[i];
            for (int i = index-1; i < arrayTwo.Length; i++)
                targetArray[i+ length] = arrayTwo[i];
            Print(targetArray);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность первого массива который вставляется: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите размерность второго массива в который идет вставка: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите индекс куда вставлять: ");
            int index = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[a];
            int[] myArray = new int[b];
            ArrayOne(array);
            Print(array);
            ArrayTwo(myArray);
            Print(myArray);
            Insert(ref array, ref myArray, index);
            Console.ReadKey();
        }
    }
}
