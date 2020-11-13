using System;
using System.ComponentModel.DataAnnotations;

namespace Quarterly.Models.Validation
{
    public class GreaterThanAttribute : ValidationAttribute
    {
        public object compareValue { get; set; }

        public GreaterThanAttribute(object val) => compareValue = val;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is int)
            {
                int valueToCheck = (int)value;
                int valueToCompare = (int)compareValue;

                if(valueToCheck > valueToCompare)
                {
                    return ValidationResult.Success;
                }
            } else if (value is DateTime)
            {
                DateTime valueToCheck = (DateTime)value;
                DateTime valueToCompare = new DateTime();

                DateTime.TryParse(valueToCompare.ToString(), out valueToCompare);

                if (valueToCheck > valueToCompare)
                {
                    return ValidationResult.Success;
                }
            } else if (value is DateTime)
            {
                double valueToCheck = (double)value;
                double valueToCompare = (double)compareValue;

                if (valueToCheck > valueToCompare)
                {
                    return ValidationResult.Success;
                }
            } else
            {
                return ValidationResult.Success;
            }

            string message = base.ErrorMessage ?? $"{validationContext.DisplayName} must be greater than {compareValue.ToString()}.";

            return new ValidationResult(message);
        }
    }
}
