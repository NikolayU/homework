using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] {
                "Ivanov Ivan Ivanovich",
                "Petrov Petr Petrovich", 
                "Sergeev Sergey Sergeevich",
                "Nikolev Nikolay Nikolaevich",
                "Dmitriev Dmitriy Dmitrievich"
            };

            string[] departments = new string[] {
            "Department of Applied Mathematics and Informatics",
            "Department of Economic Theory",
            "Department of Architectural and Building Engineering"
            };

            ListOfStudents list = new ListOfStudents();
            for (int i = 0; i < names.Length; i++)
            {
                Student student = new Student();
                student.Name = names[i];
                student.Department = departments[i % 3];
                student.Year = i % 4 + 1;
                list.Students.Add(student);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfStudents));
            FileStream fs = new FileStream("Students.xml", FileMode.Create); 
            xmlSerializer.Serialize(fs, list);
            fs.Close();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
    public class ListOfStudents 
    { 
    [XmlArray("Studens")]
    [XmlArrayItem("Student")]
    public List<Student> Students = new List<Student>();
    }
}
