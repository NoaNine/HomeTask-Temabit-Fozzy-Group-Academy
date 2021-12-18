using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TaskThreeSerialization
{
    public class Address
    {
        public string Name;
        public string City;
        public string Region;
        public string Street;
        public string House;
    }
    class Program
    {
        private void CreateXmlFile(string fileName)
        {
            Address address = new Address { Name = "Alex", City = "Kyiv", Region = "Sviatoshinskyi", Street = "Lesia Kurbasa", House = "25a" };
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Address));
            xmlSerializer.Serialize(fileStream, address);
            fileStream.Close();
        }
        void ReadXmlFile(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Address));
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            Address address = (Address) xmlSerializer.Deserialize(fileStream);
            Console.WriteLine(address.Name + "\t" + address.City + "\t" + address.Region + "\t" + address.Street + "\t" + address.House);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CreateXmlFile("Address.xml");
            program.ReadXmlFile("Address.xml");
            Console.ReadKey();
        }
    }
}
