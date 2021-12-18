using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwoHashTable
{
    class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public Product(string name, string type, double price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Type == product.Type &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = 1368981669;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
    class Provider
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            Product product1 = new Product("Хамон", "Мясо", 4);
            Product product2 = new Product("Маракуя", "Фрукт", 6);
            Product product3 = new Product("Зефир в шоколаде", "Десерт", 7.5);
            Product product4 = new Product("Вода без газа", "Вода", 3);
            Product product5 = new Product("Сухарики", "Хлебобублочное", 1.5);
            Product product6 = new Product("Гречка", "Крупа", 5.9);
            Product product7 = new Product("Гречка", "Крупа", 5.9);
            hashtable[product1] = new Provider();
            hashtable[product2] = new Provider();
            hashtable[product3] = new Provider();
            hashtable[product4] = new Provider();
            hashtable[product5] = new Provider();
            hashtable[product6] = new Provider();
            hashtable[product7] = new Provider();
            Console.WriteLine(hashtable.Count); // = 6
            Console.ReadKey();
        }
    }
}
