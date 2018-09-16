using Initializer.Entities;
using P01_BillsPaymentSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Initializer
{
   public class Initializer
    {
      
        public static void Seed(BillsPaymentSystemContext context)
        {
            InserIntoUsers(context);
            InserIntoBankAccounts(context);
            InserIntoCreditCards(context);
            InsertIntoPayments(context);
        }


        public static void InserIntoUsers(BillsPaymentSystemContext context)
        {
            var users = new UsersData().GetUsers();

            for (int i = 0; i < users.Length; i++)
            {
                if(StartUp.IsValid(users[i])==true)
                {
                    context.Add(users[i]);
                }
            }

            context.SaveChanges();
        }

        public static void InserIntoBankAccounts(BillsPaymentSystemContext context)
        {
            var accounts = new BankAccountsData().GetBankAccounts();

            for (int i = 0; i < accounts.Length; i++)
            {
                if (StartUp.IsValid(accounts[i]) == true)
                {
                    context.Add(accounts[i]);
                }
            }

            context.SaveChanges();
        }


        public static void InserIntoCreditCards(BillsPaymentSystemContext context)
        {
            var cards = new CreditCardsData().GetCreditCards();

            for (int i = 0; i < cards.Length; i++)
            {
                if (StartUp.IsValid(cards[i]) == true)
                {
                    context.Add(cards[i]);
                }
            }

            context.SaveChanges();
        }


        public static void InsertIntoPayments(BillsPaymentSystemContext context)
        {
            var payments = new PaymentMethodData().GetPayments();

            for (int i = 0; i < payments.Length; i++)
            {
                if (StartUp.IsValid(payments[i]) == true)
                {
                    context.Add(payments[i]);
                }
            }

            context.SaveChanges();
        }

    }
}
