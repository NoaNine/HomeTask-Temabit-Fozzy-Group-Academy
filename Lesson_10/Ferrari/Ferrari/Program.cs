using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrari
{
    class Ferrari
    {
        private static int _count = 0;
        public Ferrari()
        {
            if (_count < 100)
                _count++;
        }
        public static void print()
        {
            Console.WriteLine(_count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Ferrari> ferraris = new List<Ferrari>();
            for (int i = 0; i < 110; i++)
            {
                ferraris.Add(new Ferrari());
            }
            Ferrari.print();
            Console.ReadKey();
        }
    }
}
