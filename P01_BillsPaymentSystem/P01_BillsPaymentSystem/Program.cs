using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Enums;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace P01_BillsPaymentSystem
{
   public class Program
    {
      public  static void Main(string[] args)
        {
           var context = new BillsPaymentSystemContext();

            using (context)
            {
              var types = context.PaymentMethods.ToList();

                foreach (var item in types)
                {
                    Console.WriteLine(item.Type);
                }
            }

           

     }


        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }

    }
}
