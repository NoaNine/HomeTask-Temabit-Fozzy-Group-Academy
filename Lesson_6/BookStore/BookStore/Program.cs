using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStore bookStore = new BookStore();
            bookStore.DeliveryBook();
            bookStore.PrintBook();
            //string name = Console.ReadLine();
            //string genre = Console.ReadLine();
            //bookStore.ChangePriceByGenre("Фантастика", 300);
            //bookStore.SellBook(name);
            //bookStore.PrintBook();
            Console.ReadKey();
        }
    }
}

