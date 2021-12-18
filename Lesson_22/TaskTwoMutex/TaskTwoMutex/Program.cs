using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTwoMutex
{
    class 
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex(true, "MyMutex", out bool CreatedNew);
            mutex.WaitOne();
            Console.WriteLine("This process closed named mutex. Press enter to open named mutex");
            Console.ReadLine();
            mutex.ReleaseMutex();
        }
    }
}
