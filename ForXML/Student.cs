using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForXML
{
    public class Student
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }

        [XmlElement("Department")]
        public string Department { get; set; }
    }
}
