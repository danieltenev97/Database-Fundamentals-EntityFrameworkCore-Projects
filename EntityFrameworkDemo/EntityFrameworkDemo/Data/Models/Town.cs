using System;
using System.Collections.Generic;

namespace P02_DatabaseFirst.Data.Models
{
    public  class Town
    {
        public Town()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int? TownId { get; set; }
        public string Name { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
