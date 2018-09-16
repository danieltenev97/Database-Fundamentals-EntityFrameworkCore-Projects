using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Querrying
{
   public  class UserInfoDto
    {

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int? age { get; set; }

        public SoldProductsDto soldProducts { get; set; }
    }
}
