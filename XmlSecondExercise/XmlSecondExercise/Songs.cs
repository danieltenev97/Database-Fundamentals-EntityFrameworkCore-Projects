using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlSecondExercise
{
    [XmlType("song")]
  public class Songs
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlAttribute("length")]
        public string Length { get; set; }
        [XmlElement("description")]
        public Description Description { get; set; }

    }
}
