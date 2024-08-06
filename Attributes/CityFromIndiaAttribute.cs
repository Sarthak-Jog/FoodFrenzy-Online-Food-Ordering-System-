using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FoodFrenzy.Attributes
{
    public class CityFromIndiaAttribute : ValidationAttribute
    {
        private static readonly HashSet<string> CitiesInIndia = new HashSet<string>
        {
            "Mumbai", "Delhi", "Bangalore", "Hyderabad", "Ahmedabad",
            "Chennai", "Kolkata", "Surat", "Pune", "Jaipur"
            // Add more cities as needed
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("City name is required.");
            }

            var cityName = value.ToString();
            if (!CitiesInIndia.Contains(cityName))
            {
                return new ValidationResult($"'{cityName}' is not a valid city in India.");
            }

            return ValidationResult.Success;
        }
    }
}
