using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Initializer.Entities
{
    public class UsersData
    {

        public User[] GetUsers()
        {
            var users = new User[]
            {
              new User() { FirstName="Daniel", LasrName="Tenev",Email="dtenev@abv.bg",Password="agagahaga"},
              new User() { FirstName="Pavlin", LasrName="Mitev",Email="mitev@abv.bg",Password="imgonnabeatyou"},
              new User() { FirstName="Sofia", LasrName="Pavlova",Email="sofi@abv.bg",Password="gtaakgqajta"},
               new User() { FirstName="Vencislav", LasrName="Vencislavov",Email="venata@abv.bg",Password="samounited"}

            };


            return users;
        }

    }
}
