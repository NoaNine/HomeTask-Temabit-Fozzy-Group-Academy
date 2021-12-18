using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abramovych
{
    class Entertainment
    {
        private int _priceFireWorks = 2799;
        public void FireWorks(ref int wallet)
        {
            wallet -= _priceFireWorks;
            Console.WriteLine("Launch FireWorks");
        }
        private int _priceDisco = 1450;
        public void Disco(ref int wallet)
        {
            wallet -= _priceDisco;
            Console.WriteLine("Turn on the music and everyone dance");
        }
    }
    class Kitchen
    {
        private int _price = 995;
        public void Feed(ref int wallet)
        {
            wallet -= _price;
            Console.WriteLine("Serve all dishes from the menu");
        }
    }
    public delegate void TamadaDelegate(ref int price);
    class Abramovych
    {
        private int _wallet = 10000;
        public event TamadaDelegate Party;
        public void CorporateParty()
        {
            Console.WriteLine("Money " + _wallet);
            Party(ref _wallet);
            Console.WriteLine("Left money " + _wallet);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Abramovych abramovych = new Abramovych();
            Entertainment entertainment = new Entertainment();
            Kitchen kitchen = new Kitchen();
            abramovych.Party += kitchen.Feed;
            abramovych.Party += entertainment.FireWorks;
            abramovych.Party += entertainment.Disco;
            abramovych.CorporateParty();
            Console.ReadKey();
        }
    }
}
