using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    public class Student
    {
        public string Name { get; private set; }
        public string Faculty { get; private set; }
        public double Gpa { get; private set; }
        public Student(string name, string faculty, double gpa)
        {
            Name = name;
            Faculty = faculty;
            Gpa = gpa;
        }
    }
    public class City
    {
        public string CityName { get; private set; }
        public string RegionName { get; private set; }
        public City(string nameCity, string nameRegion)
        {
            CityName = nameCity;
            RegionName = nameRegion;
        }
    }
    public class MyComparer : IComparer<City>
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public int Compare(City x, City y)
        {
            int result = comparer.Compare(y.CityName, x.CityName);
            if (result == 0)
                return 1;
            else
                return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City("kyiv", "Kyiv Region");
            City city2 = new City("Lviv", "Lviv Region");
            City city3 = new City("Odessa", "Odessa Region");
            SortedList<City, Student> sortedList = new SortedList<City, Student>(new MyComparer());
            sortedList[city1] = new Student("Kolia", "Economic", 3.9);
            sortedList[city1] = new Student("Ilia", "Economic", 4);
            sortedList[city3] = new Student("Sasha", "IT", 4.2);
            sortedList[city2] = new Student("Vika", "IT", 4.7);
            sortedList[city2] = new Student("Lera", "Economic", 4.8);
            foreach ( var i in sortedList)
            {
                Console.WriteLine(i.Key.CityName + "\t"+ i.Key.RegionName + "\t" + i.Value.Name + "\t" + i.Value.Faculty + "\t" + i.Value.Gpa);
            }
            Console.ReadKey();
        }
    }
}
