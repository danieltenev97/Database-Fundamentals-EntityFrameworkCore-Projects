using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationAndAttribuesValidationDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var student = new Student()
            {
                Id=1,
                Name="Daniel",
                Age=2,
               
                LessonId=2
                
            };

            bool valid = isValid(student);

            Console.WriteLine(valid);
            Console.WriteLine("Hello World!");
        }

        public static bool isValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }

    }
}
