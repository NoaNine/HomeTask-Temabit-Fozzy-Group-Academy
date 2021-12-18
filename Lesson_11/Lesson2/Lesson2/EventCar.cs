using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson
{
    public delegate void DamageInfoDelegate();
    class CarComputer
    {
        public void CriticalDamage()
        {
            Console.WriteLine("Хана движку");
        }
    }
    class Car
    {
        public event DamageInfoDelegate DamageInfoEvent;
        public void Moove()
        {
            for (int speed = 0; speed < 320; speed += 10)
            {
                Console.WriteLine(speed);
                if (speed == 290)
                {
                    DamageInfoEvent();
                    break;
                }    
            }
        }
    }
    class EventCar
    {
        static void Main(string[] args)
        {
            CarComputer carComputer = new CarComputer();
            Car car = new Car();    
            car.DamageInfoEvent += carComputer.CriticalDamage;
            car.Moove();
            Console.ReadKey();
        }
    }
}