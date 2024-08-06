using System.ComponentModel.DataAnnotations;

namespace FoodFrenzy.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(45, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.[A-Z])(?=.[!@#$%^&*()_+=\[{\]};:<>|./?,-]).+$", ErrorMessage = "Password must contain at least one uppercase letter and one special character")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters")]
        public string? Address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number must be exactly 10 digits.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Contact number must be a valid Indian mobile number.")]
        public string CustomerContactNo { get; set; }
       public ICollection<Review> Reviews { get; set; }
       public ICollection<Address> Addresses { get; set; }

    }
}
