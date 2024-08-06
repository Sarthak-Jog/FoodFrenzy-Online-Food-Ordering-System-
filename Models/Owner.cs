using System.ComponentModel.DataAnnotations;

namespace FoodFrenzy.Models
{
    public class Owner
    {
        [Key]
        [Required]
        public int OwnerId { get; set; }

        [Display(Name = "Owner Name")]
        [Required]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string OwnerEmail { get; set; }
    }
}
