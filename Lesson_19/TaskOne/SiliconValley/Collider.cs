using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconValley
{
    public class Collider : SmartWatch
    {
        public void PrintCollider()
        {
            Console.WriteLine("Collider it is working");
        }
        public void UseSegway()
        {
            Segway segway = new Segway();
            segway.Print();
        }
        public void UseSmartWatch()
        {
            PrintSmartWatch();
        }
    }
}
