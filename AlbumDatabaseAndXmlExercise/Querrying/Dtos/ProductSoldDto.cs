using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying.Dtos
{
    [XmlType("product")]
    public class ProductSoldDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }

    }
}
