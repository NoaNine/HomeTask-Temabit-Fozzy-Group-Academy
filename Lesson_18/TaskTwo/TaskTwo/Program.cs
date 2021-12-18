using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 0009586,
                    Name = "Хамон",
                    Type = "Мясо",
                    Price = 116.6
                },
                new Product
                {
                    Id = 0009846,
                    Name = "Кока-кола",
                    Type = "Напитки",
                    Price = 23.20
                },
                new Product
                {
                    Id = 0009171,
                    Name = "Апельсин",
                    Type = "Фрукты",
                    Price = 40
                },
                new Product
                {
                    Id = 0002746,
                    Name = "Щука",
                    Type = "Рыба",
                    Price = 79.99
                }
            };
            var query = from product in products
                        where product.Price >= 30
                        select product;
            foreach (Product product in query)
                Console.WriteLine($"{product.Name} - {product.Price}");
            Console.ReadKey();
        }
    }
}
