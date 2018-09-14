using System;
using System.ComponentModel.DataAnnotations;

namespace Samples.Client.Model.Shared.Validation
{
    public class DoublePositiveValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var number = (double) value;
                if (number < 0.0)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Number is invalid");
            }
            return ValidationResult.Success;
        }
    }
}