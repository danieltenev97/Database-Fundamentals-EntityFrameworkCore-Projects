using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Querrying
{
    [XmlType("category")]
   public class CategoriesByProductsCountDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("products-count")]
        public int ProductsCount { get; set; }
        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }
        [XmlElement("revenue-count")]
        public decimal TotalRevenue { get; set; }

    }
}
