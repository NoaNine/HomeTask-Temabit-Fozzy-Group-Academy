using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    struct Book
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public Book(string name, string genre, string author, double price)
        {
            Name = name;
            Author = author;
            Genre = genre;
            Price = price;
        }
    }
}
