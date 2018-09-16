using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying.Dtos
{

    [XmlType("user")]
    public class UsersSoldDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }
        [XmlAttribute("last-name")]
        public string LastName { get; set; }
        [XmlArray("sold-products")]
        public ProductSoldDto[] productSolds { get; set; }
    } 
}
