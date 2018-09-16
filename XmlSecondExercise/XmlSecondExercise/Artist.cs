using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlSecondExercise
{
    [XmlType("artist")]
   public class Artist
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray("albums")]
        public Albums[] Albums { get; set; } 

    }
}
