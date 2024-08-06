using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodFrenzy.Attributes;

namespace FoodFrenzy.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters")]
        [CityFromIndia]
        public string? address { get; set; }

        [Required]
        [RegularExpression(@"^[1-9][0-9]{5}$", ErrorMessage = "Zip code must be a valid Indian PIN code.")]
        public string ZipCode { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

    }
}
