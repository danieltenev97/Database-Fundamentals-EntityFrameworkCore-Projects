using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace AlbumDatabaseAndXmlExercise.Dtos
{
    [XmlType("category")]
    public class CategoriesDto
    {
        [Range(3,15)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
