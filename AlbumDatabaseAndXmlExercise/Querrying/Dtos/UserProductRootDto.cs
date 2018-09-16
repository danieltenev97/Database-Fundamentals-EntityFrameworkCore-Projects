using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying.Dtos
{
    [XmlRoot()]
   public class UserProductRootDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("user")]
        public UserDto[] Users { get; set; }
    }
}
