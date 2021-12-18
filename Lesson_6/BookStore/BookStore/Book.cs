using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Book
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public Book(string name, string genre, double price)
        {
            Name = name;
            Genre = genre;
            Price = price;
        }
    }
}
