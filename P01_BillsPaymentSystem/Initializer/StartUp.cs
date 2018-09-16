using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01_BillsPaymentSystem;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace Initializer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BillsPaymentSystemContext();

            using (context)
            {
                Initializer.Seed(context);
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
