using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying.Dtos
{
    [XmlType("sold-product")]
    public class SoldProductsDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("products")]
        public ProductDto[] Products { get; set; } 


    }
}
