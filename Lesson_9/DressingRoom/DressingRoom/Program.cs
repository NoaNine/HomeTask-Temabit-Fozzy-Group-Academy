using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingRoom
{
    class Program  //незаконченная задача! ошибка возникает
    {
        static void Main(string[] args)
        {
            DressingRoom dressingRoom = new DressingRoom(10);
            dressingRoom[0] = new Clothing { Name = "Черное пальто" };
            dressingRoom[1] = new Clothing { Name = "Шуба" };
            Console.WriteLine(dressingRoom[0].Name);
            Console.ReadKey();
        }
    }
}
