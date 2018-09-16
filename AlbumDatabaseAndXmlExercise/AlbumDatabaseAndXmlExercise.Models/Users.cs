using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlbumDatabaseAndXmlExercise.Models
{
  public  class Users
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [InverseProperty("Bought")]
        public ICollection<Products> Bought { get; set; } = new HashSet<Products>();
        [InverseProperty("Sold")]
        public ICollection<Products> Sold { get; set; } = new HashSet<Products>();



    }
}
