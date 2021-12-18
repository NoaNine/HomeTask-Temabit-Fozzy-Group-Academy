using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task_One
{
    public class City
    {
        public string NameCity { get; set; }
        public City(string nameCity)
        {
            NameCity = nameCity;
        }
    }
    public class AddressInfo
    {
        public string Address { get; set; }
        public City City;
        public AddressInfo(string address)
        {
            Address = address;
        }
        public AddressInfo AddressInfoClone()
        {
            AddressInfo address = (AddressInfo)this.MemberwiseClone();
            address.City = new City(City.NameCity);
            address.Address = String.Copy(Address);
            return address;
        }
    }
    public class Student 
    {
        public string Name { get; set; }
        public AddressInfo AddressInfo;
        public Student StudentClone()
        {
            Student student = (Student)this.MemberwiseClone();
            student.AddressInfo = new AddressInfo(AddressInfo.Address);
            student.Name = String.Copy(Name);
            return student;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student studentOriginal = new Student();
            studentOriginal.Name = "Ivan";
            studentOriginal.AddressInfo = new AddressInfo("Pushkina");
            studentOriginal.AddressInfo.City = new City("Kyiv");
            Student studentClone = studentOriginal.StudentClone();
            studentOriginal.AddressInfo.City.NameCity = "Ternopil";
            studentClone.AddressInfo.City = new City("Kyiv");
            studentClone.AddressInfo.AddressInfoClone();
            Console.WriteLine("Original: " + studentOriginal.Name + " " + studentOriginal.AddressInfo.Address + " " + studentOriginal.AddressInfo.City.NameCity);
            Console.WriteLine("Clone: " + studentClone.Name + " " + studentClone.AddressInfo.Address + " " + studentClone.AddressInfo.City.NameCity);
            studentOriginal.Name = "Nina";
            studentOriginal.AddressInfo.Address = "Kurbasa";
            studentOriginal.AddressInfo.City.NameCity = "Odessa";
            Console.WriteLine("Original: " + studentOriginal.Name + " " + studentOriginal.AddressInfo.Address + " " + studentOriginal.AddressInfo.City.NameCity);
            Console.WriteLine("Clone: " + studentClone.Name + " " + studentClone.AddressInfo.Address + " " + studentClone.AddressInfo.City.NameCity);
            Console.ReadKey();
        }
    }
}
