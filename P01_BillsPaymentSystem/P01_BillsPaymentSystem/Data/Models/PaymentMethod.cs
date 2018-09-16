using P01_BillsPaymentSystem.Attributes;
using P01_BillsPaymentSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
   public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public PaymentMethodType Type { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(CreditCardId))]
        [ForeignKey("BankAccount")]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        [ForeignKey("CreditCard")]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
