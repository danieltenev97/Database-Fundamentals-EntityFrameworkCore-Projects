using P01_BillsPaymentSystem.Data.Enums;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Initializer.Entities
{
  public  class PaymentMethodData
    {

       public PaymentMethod[] GetPayments()
        {
            PaymentMethod[] payments = new PaymentMethod[]
            {
                new PaymentMethod() {UserId=1,Type=PaymentMethodType.BankAccount,BankAccountId=1},
                new PaymentMethod() {UserId=2,Type=PaymentMethodType.BankAccount,BankAccountId=3},
                new PaymentMethod() {UserId=3,Type=PaymentMethodType.CreditCard,CreditCardId=1},
                new PaymentMethod() {UserId=1,Type=PaymentMethodType.BankAccount,BankAccountId=2,CreditCardId=2},
                new PaymentMethod() {UserId=4,Type=PaymentMethodType.BankAccount,BankAccountId=2},
            };

            return payments;
        }

    }
}
