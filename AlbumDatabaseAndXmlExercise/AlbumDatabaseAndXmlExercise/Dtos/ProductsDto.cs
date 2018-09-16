using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace AlbumDatabaseAndXmlExercise.Dtos
{
    [XmlType("product")]
  public class ProductsDto
    {
       [XmlElement("name")]
       [MinLength(3)]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }

    }
}
