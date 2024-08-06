using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FoodFrenzy.Attributes
{
    public class IndianCurrencyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Bill Amount is required.");
            }

            if (value is decimal amount)
            {
                // You can further validate if amount is within certain limits if required
                if (amount <= 0)
                {
                    return new ValidationResult("Bill Amount must be greater than 0.");
                }

                // Format as Indian currency
                var indianCurrencyFormat = string.Format(new CultureInfo("en-IN"), "{0:C}", amount);

                // Additional custom validation can be added here if required

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid Bill Amount.");
        }
    }
}
