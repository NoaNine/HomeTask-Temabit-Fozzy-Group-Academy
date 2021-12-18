using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson
{
    public delegate void MyDelegate();
    class Delegate
    {
        private static void Odd()
        {
            Console.WriteLine("Нечетный");
        }

        private static void Even()
        {
            Console.WriteLine("Четный");
        }
        static void Main(string[] args)
        {
            List<MyDelegate> myDelegates = new List<MyDelegate>();
            for (var i = 0; i< 10; i++)
            {
                if (i % 2 == 0)
                    myDelegates.Add(new MyDelegate(Even));
                else
                    myDelegates.Add(new MyDelegate(Odd));
            }
            foreach(MyDelegate myDelegate in myDelegates)
            {
                myDelegate.Invoke();
            }
            Console.ReadKey();
        }
    }
}
