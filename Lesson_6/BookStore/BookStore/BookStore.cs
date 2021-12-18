using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BookStore
    {
        private List<Book> _books = new List<Book>();
        private void AddBook(string name, string genre, double price)
        {
            Book book = new Book(name, genre, price);
            _books.Add(book);
        }
        public void DeliveryBook()
        {
            AddBook("Цветы для Элджернона", "Фантастика", 56.60);
            AddBook("Играть что бы жить", "Фентези", 88);
            AddBook("Человек невидимка", "Фантастика", 43.50);
            AddBook("Бегающий сейф", "Комедия", 99.99);
            AddBook("Искажающие реальность", "Фентези", 38);
        }
        private double _cashBox = 100;
        public void SellBook(string name)
        {
            Book searchName = _books.Find(n => n.Name == name);
            _cashBox += searchName.Price;
            _books.Remove(searchName);
        }
        public void ChangePriceByGenre(string genre, double murkup)
        {
            List<Book> searchG = new List<Book>();
            searchG = _books.FindAll(g => g.Genre == genre);
            for (int i = 0; i < searchG.Count; i++)
            {
                searchG[i].Price += murkup;
            }
        }
        public void PrintBook()
        {
            foreach (Book i in _books)
            {
                Console.WriteLine(i.Name + " " + i.Genre + " " + i.Price);
            }
        }
    }
}
