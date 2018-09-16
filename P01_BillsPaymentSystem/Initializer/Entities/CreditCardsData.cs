using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Initializer.Entities
{
  public  class CreditCardsData
    {

        public CreditCard[]  GetCreditCards()
        {
            CreditCard[] cards = new CreditCard[]
            {
                new CreditCard() {Limit=195,MoneyOwed=0,ExpirationDate=DateTime.Now.AddMonths(-8)},
                new CreditCard() {Limit=2195,MoneyOwed=154,ExpirationDate=DateTime.Now.AddMonths(4)},
                new CreditCard() {Limit=100000,MoneyOwed=27000,ExpirationDate=DateTime.Now.AddMonths(-2)},
                new CreditCard() {Limit=447,MoneyOwed=0,ExpirationDate=DateTime.Now}

            };

            return cards;
        }
             
    }
}
