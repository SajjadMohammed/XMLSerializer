using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defining an object
            var student = new Student
            {
                Id = 1,
                FullName = "Ahmed Ameen Ali",
                Address = "Kirkuk",
                Age = 23
            };
            XMLSerialize(student);
            var stu = XMLDeserialize("xmlfile.xml");
            Console.WriteLine($"{stu.Id} : {stu.FullName} : {stu.Address} : {stu.Age}");
            Console.ReadKey();
        }

        static void XMLSerialize(Student student)
        {
            using (var xmlFile = File.Create("xmlfile.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Student));
                xmlSerializer.Serialize(xmlFile, student);
            }
        }

        static Student XMLDeserialize(string filePath)
        {
            using (var xmlFile = File.OpenRead(filePath))
            {
                var xmlDeserializer = new XmlSerializer(typeof(Student));
                var student = xmlDeserializer.Deserialize(xmlFile) as Student;
                return student;
            }
        }
    }
}
