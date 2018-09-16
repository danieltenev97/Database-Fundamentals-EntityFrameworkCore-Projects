using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        [StringLength(50)]
        public string BankName { get; set; }
        [StringLength(20)]
        public string SWIFTCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
   
    }
}
