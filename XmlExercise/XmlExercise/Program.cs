using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Exam> exams = new List<Exam>()
           {
                new Exam()
                {
                    Name = "Programming Basics",
                    TakenDate = "2017/12/16",
                    Grade = 5.65
                },
                new Exam()
                {
                    Name = "Database Basics",
                    TakenDate = "2018/06/24",
                    Grade = 5.82
                }
            }; 



            var student = new Student()
            {

            Name="Ivan Ivanov",
                Gender="Male",
                BirthDate="1999/12/23",
                PhoneNumber="+359459151",
                Email="ivanivanonov@gmail.com",
                University="Software University",
                Specialty="C# Developer",
                FacultyNumber="141415223",
                Exams=exams
           }; 

            var serializer = new XmlSerializer(typeof(Student));

             var writer = new StreamWriter("Student.xml");

             using (writer)
              {
                  serializer.Serialize(writer, student);
              } 

            
        }
    }
}
