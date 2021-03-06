﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAndAttribuesValidationDemo
{
    [AttributeUsage(AttributeTargets.Property)]
   public class XorAttribute : ValidationAttribute
    {
        private string Parameter { get; set; }

        public XorAttribute(string parameter)
        {
            this.Parameter = parameter;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetProperty = validationContext.ObjectType.GetProperty(Parameter).GetValue(validationContext.ObjectInstance);

            if((targetProperty==null&&value!=null)|| (targetProperty != null && value == null))
            
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The property must be postive");

           // return base.IsValid(value, validationContext);
        }


    }
}
