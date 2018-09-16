using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumDatabaseAndXmlExercise.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Bought")]
        public int? BuyerId { get; set; }
        [ForeignKey("Sold")]
        public int Sellerid { get; set; }

        public Users Sold { get; set; }
        public Users Bought { get; set; }

        public ICollection<CategoryProducts> categoryProducts { get; set; } = new HashSet<CategoryProducts>();
    }
}
