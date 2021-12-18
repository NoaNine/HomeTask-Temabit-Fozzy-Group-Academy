using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperArray
{
    class Developer_array
    {
        public static void Filling(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 10);
            }
        }
        public static bool Check(int[] array, int value)
        {
            foreach (int i in array)
                if (i == value)
                    return true;
                else
                    return false;
            return false;
        }
        public static void Insert (ref int[] array, int value, int index)
        {
            int[] newArray = new int[array.Length + 1];
            newArray[index - 1] = value;
            for (int i = 0; i < index-1; i++)
                newArray[i] = array[i];
            for (int i = index-1; i < array.Length; i++)
                newArray[i+1] = array[i];
            array = newArray;
        }
        public static void AddFirst (ref int[] array, int value)
        {
            Insert(ref array, value, 1);
        }
        public static void AddLast (ref int[] array, int value)
        {
            Insert(ref array, value, array.Length+1);
        }
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] developer = new int[5];
            Filling(developer);
            Print(developer);
            Insert(ref developer, -1, 2);
            Print(developer);
            AddFirst(ref developer, -2);
            Print(developer);
            AddLast(ref developer, -3);
            Print(developer);
            if (Check(developer, -2) == true) 
                Console.WriteLine("Element to arraying - true");
            else
                Console.WriteLine("Element to arraying - false");
            Console.ReadKey();
        }
    }
}
