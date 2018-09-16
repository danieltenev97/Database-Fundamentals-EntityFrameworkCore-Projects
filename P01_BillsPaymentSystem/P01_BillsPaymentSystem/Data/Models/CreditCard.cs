using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
  public  class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft => Limit - MoneyOwed;
        public DateTime ExpirationDate { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
    }
}
