using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    class Product
    {
        public string Name { get; private set; }
        public bool VipStatus { get; private set; }
        public Product(string name, bool vipStatus)
        {
            VipStatus = vipStatus;
            Name = name;
        }
    }
    class Silpo
    {
        private Product[] _products;
        public Silpo()
        {
            _products = new Product[] {
                new Product("Хамон", true),
                new Product("Маракуя", true),
                new Product("Зефир в шоколаде", true),
                new Product("Вода без газа", false),
                new Product("Сухарики", false),
                new Product("Гречка", false)};
        }
        public IEnumerable GetProduct(bool vip)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (vip == _products[i].VipStatus)
                    yield return _products[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Silpo silpo = new Silpo();
            bool Vip = true;
            foreach(Product product in silpo.GetProduct(Vip))
            {
                Console.WriteLine(product.Name);
            }
            Console.ReadKey();
        }
    }
}
