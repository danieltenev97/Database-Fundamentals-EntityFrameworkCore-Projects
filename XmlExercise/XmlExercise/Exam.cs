using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlExercise1
{
    [XmlType("exam")]
    public class Exam
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("takenDate")]
        public string TakenDate { get; set; }
        [XmlElement("grade")]
        public double Grade { get; set; }

    }
}
