using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Mather
    {
        public void Question(string message)
        {
            Console.WriteLine(message); 
        }
    }
    class FireDepartment
    {
        public void FireTruck()
        {
            Console.WriteLine("Arrived a Fire Truck");
        }
    }
    class Friend
    {
        public void Idiot()
        {
            Console.WriteLine("Loudly playing music...");
            Console.WriteLine("he he he");
        }
    }
    public delegate void MatherDelegate(string message);
    public delegate void FireDepartmentDelegate();
    public delegate void FriendDelegate();
    class Hous
    {
        public event FriendDelegate Birthday;
        public event FireDepartmentDelegate HappenedFire;
        public event MatherDelegate ArrivedMather;
        public void Event(string message)
        {
            HappenedFire.Invoke();
            Birthday.Invoke();
            ArrivedMather?.Invoke(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hous hous = new Hous();
            FireDepartment fireDepartment = new FireDepartment();
            Friend friend = new Friend();
            Mather mather = new Mather();
            hous.HappenedFire += fireDepartment.FireTruck;
            hous.Birthday += friend.Idiot;
            hous.ArrivedMather += mather.Question; 
            hous.Event("Who is this girl?");
            Console.ReadKey();
        }
    }
}
