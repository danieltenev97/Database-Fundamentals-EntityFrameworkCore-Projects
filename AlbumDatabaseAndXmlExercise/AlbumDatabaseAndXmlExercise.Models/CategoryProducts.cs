using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumDatabaseAndXmlExercise.Models
{
   public class CategoryProducts
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Products products { get; set; }
        public Categories Categories { get; set; }

    }
}
