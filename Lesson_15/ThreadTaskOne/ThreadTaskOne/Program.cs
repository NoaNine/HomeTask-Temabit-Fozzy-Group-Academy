using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ThreadTaskOne
{
    class Program
    {
        public static void CountTwo()
        {
            for (int i = 9; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
        }
        static object block = new object();
        public static void CountOne()
        {
            lock (block)
            {
                Thread threadThree = new Thread(CountTwo);
                threadThree.IsBackground = true;
                threadThree.Start();
                for (int i = 1; i <= 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, i);
                    Thread.Sleep(100);
                }
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread threadTwo = new Thread(CountOne);
                threadTwo.Name = "Поток " + i.ToString();
                threadTwo.Start();
            }

            Console.ReadLine();
        }
    }
}
