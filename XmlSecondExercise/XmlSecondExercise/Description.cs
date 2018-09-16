using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlSecondExercise
{
    [XmlType("description")]
   public class Description
    {
        [XmlAttribute("link")]
        public string Link { get; set; }
        [XmlText]
        public string description { get; set; }
    }
}
