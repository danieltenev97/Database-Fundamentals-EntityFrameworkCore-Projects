using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlbumDatabaseAndXmlExercise.Models
{
   public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Range(3,15)]
        [Required]
        public string Name { get; set; }

        public ICollection<CategoryProducts> categoryProducts { get; set; } = new HashSet<CategoryProducts>();
    }
}
