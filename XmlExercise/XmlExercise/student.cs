using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlExercise1
{
    [XmlRoot("student")]
   public class Student
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("gender")]
        public string Gender { get; set; }
        [XmlElement("birthDate")]
        public string BirthDate { get; set; }
        [XmlElement("phoneNumber")]
        public string PhoneNumber { get; set; }
        [XmlElement("email")]
        public string Email { get; set; }
        [XmlElement("university")]
        public string University { get; set; }
        [XmlElement("specialty")]
        public string Specialty { get; set; }
        [XmlElement("facultyNumber")]
        public string FacultyNumber { get; set; }
        [XmlArray("exams")]
        public List<Exam> Exams { get; set; } = new List<Exam>();

    }
}
