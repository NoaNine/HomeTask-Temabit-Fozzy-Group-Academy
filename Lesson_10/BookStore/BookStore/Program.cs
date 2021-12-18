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
            Console.WriteLine(bookStore[0].Name);
            Console.WriteLine(bookStore["Петрович"].Name);
            List<Book> books = new List<Book>();
            books = bookStore["Фантастика", 60];
            for (var i = 0; i<books.Count; i++)
            {
                Console.WriteLine(books[i].Name + " " + books[i].Genre + " " + books[i].Author + " " + books[i].Price);
            }
            //string name = Console.ReadLine();
            //string genre = Console.ReadLine();
            //bookStore.ChangePriceByGenre("Фантастика", 300);
            //bookStore.SellBook(name);
            //bookStore.PrintBook();
            Console.ReadKey();
        }
    }
}

