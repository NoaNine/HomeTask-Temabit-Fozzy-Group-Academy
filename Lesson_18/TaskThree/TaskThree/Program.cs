using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TaskThree
{
    public class Car
    {
        public string ModelCar { get; set; }
        public int YearIssue { get; set; }
        public string Color { get; set; }
        public Car(string modelCar, int yearIssue, string color)
        {
            ModelCar = modelCar;
            YearIssue = yearIssue;
            Color = color;
        }
    }
    public class Owner
    {
        public string ModelCar { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public Owner(string modelCar, string name, int numberPhone)
        {
            ModelCar = modelCar;
            Name = name;
            NumberPhone = numberPhone;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car("Mercedes", 2018, "Black"),
                new Car("Ferrari", 2010, "Red"),
                new Car("BMW", 2005, "Black"),
                new Car("Ford", 2000, "Blue"),
                new Car("Ford", 2020, "Black"),
            };
            List<Owner> owners = new List<Owner>
            {
                new Owner("Ferrari", "Иванов", 0974567783),
                new Owner("Mercedes", "Шевченко", 0996565783),
                new Owner("Ford", "Абрамович", 0934446683),
                new Owner("Ford", "Кулик", 0974565465),
                new Owner("BMW", "Дрозд", 0963478799),
            };
            var query = from car in cars
                        join owner in owners on car.ModelCar equals owner.ModelCar
                        orderby owner.Name
                        select new { ModelCar = car.ModelCar, YearIssue = car.YearIssue, Color = car.Color, Name = owner.Name, NumberPhone = owner.NumberPhone };
            foreach(var owner in query)
                Console.WriteLine($"{owner.Name} - {owner.NumberPhone} - {owner.ModelCar} - {owner.Color} - {owner.YearIssue}");
            Console.ReadKey();
        }
    }
}
