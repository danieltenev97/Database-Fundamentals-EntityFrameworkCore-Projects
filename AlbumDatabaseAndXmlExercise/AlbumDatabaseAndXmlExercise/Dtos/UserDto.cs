using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace AlbumDatabaseAndXmlExercise.Dtos
{
    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute("firstName")]
        public string Firstname { get; set; }
        [XmlAttribute("lastName")]
        [MinLength(3)]
        public string Lastname {get; set; }
        [XmlAttribute("age")]
        public string Age { get; set; }
    }
}
