using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LessonTask
{
    class Program
    {
        static int Sum(int a, int b)
        {
            Thread.Sleep(1000);
            return a + b;
        }
        static void CallBack(IAsyncResult asyncResult)
        {
            Func<int, int, int> exampleFunc = (Func<int, int, int>)asyncResult.AsyncState;
            int sum = exampleFunc.EndInvoke(asyncResult);
            Console.WriteLine("Sum - {0}", sum);
        }
        static Func<int, int, int> func = new Func<int, int, int>(Sum);
        static void Main(string[] args)
        {
            IAsyncResult asyncResult = func.BeginInvoke(1, 2, CallBack, func);
            Console.WriteLine("First thread is completed");
            Console.ReadKey();
        }
    }
}
