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
        {
            {
                Random rnd = new Random();
                int n = 20;
                int rage = 1000;
                int min = rage;
                int[] array = new int[n];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(rage);
                    Console.WriteLine(array[i]);
                }
                for (int i = 0; i < array.Length; i++)
                {
                    if ((array[i] & 1) == 0 && array[i] < min)
                        min = array[i];
                }
                //foreach (int i in array) // проблема с циклом фореч при переборе массива на поиск значений
                //{
                //    if ((array[i] & 1) == 0 && array[i] < min)
                //        Console.WriteLine("Минимальное четное число массива {0}", array[i]);
                //}
                Console.WriteLine("Минимальное четное число массива {0}", min);
                Console.ReadKey();
            }
            //for (int i = 0; i < jagged.Length; i++) //не смог разобраться с выбором четных строк массива
            //{
            //    if ((i & 1) == 0)
            //    {
            //        for (int j = 0; j < jagged[i].Length; j++)
            //        {
            //            if ((jagged[i][j] & 1) == 1 && jagged[i][j] < min)
            //                min = jagged[i][j];
            //        }
            //    }
            //}
            //Console.WriteLine("Минимальное число среди нечетных значений и в четных строках " + min);
        }
    }
}
