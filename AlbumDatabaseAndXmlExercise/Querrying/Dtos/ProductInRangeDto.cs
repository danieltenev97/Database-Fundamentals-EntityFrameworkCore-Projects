using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying.Dtos
{
    [XmlType("product")]
    public class ProductInRangeDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public string Price { get; set; }
        [XmlAttribute("buyer")]
        public string BuyerName { get; set; }

    }
}
