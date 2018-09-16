using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlSecondExercise
{
    [XmlType("album")]
   public class Albums
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("song")]
        public Songs[] song { get; set; }
    }
}
