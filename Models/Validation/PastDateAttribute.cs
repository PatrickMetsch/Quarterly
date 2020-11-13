using System;
using System.ComponentModel.DataAnnotations;

namespace Quarterly.Models.Validation
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;

                if (dateToCheck < DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            string message = base.ErrorMessage ?? $"{validationContext.DisplayName} must be a valid past date.";

            return new ValidationResult(message);
        }
    }
}
