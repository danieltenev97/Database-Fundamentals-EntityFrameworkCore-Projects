using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonersExportDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }
      
        [XmlElement("Name")]
        public string FullName { get; set; }
        [XmlElement("IncarcerationDate")]
      
        public string IncarcerationDate { get; set; }
        [XmlArray("EncryptedMessages")]
        public MailDto[] mailDtos { get; set; }

    }
}
