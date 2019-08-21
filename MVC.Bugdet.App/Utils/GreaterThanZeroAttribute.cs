using System.ComponentModel.DataAnnotations;

namespace MVC.Bugdet.App.Utils
{
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            decimal number = (decimal)value;
            if (number > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Value must be greater than zero.");
        }
    }
}