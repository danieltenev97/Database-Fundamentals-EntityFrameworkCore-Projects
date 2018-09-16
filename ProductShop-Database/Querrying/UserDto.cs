using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Querrying
{
   public class UserDto
    {
        public int usersCount { get; set; }

        public UserInfoDto[] users { get; set; }
    }
}
