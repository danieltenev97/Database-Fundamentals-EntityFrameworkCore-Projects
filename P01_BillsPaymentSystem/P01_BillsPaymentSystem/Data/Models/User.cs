using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LasrName { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();


    }
}
