using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Four
{
    class Task_4
    {
        public static void MaxNum(byte a, byte b)
        {
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число ");
            byte a = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число ");
            byte b = byte.Parse(Console.ReadLine());
            int x = b & ((a - b) >> 31) | a & (~(a - b) >> 31); // 31 для int
            Console.WriteLine("Наибольшее число " + x);
            Console.ReadKey();
        }
    }
}
