using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Initializer.Entities
{
    public class BankAccountsData
    {
        public BankAccount[] GetBankAccounts()
        {

            BankAccount[] accounts = new BankAccount[]
            {
            new BankAccount() { BankName="RaifaisenBank",Balance=399,SWIFTCode="RFB"},
            new BankAccount() { BankName="UnicreditBank",Balance=4217,SWIFTCode="UNK"},
            new BankAccount() { BankName="BankaDSK",Balance=187,SWIFTCode="DSK"},
             new BankAccount() { BankName="Pireus",Balance=54000,SWIFTCode="PRK"}

            };
            return accounts;
        }
    }
}
