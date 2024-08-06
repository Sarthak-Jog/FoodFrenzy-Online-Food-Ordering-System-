using System.ComponentModel.DataAnnotations;

namespace FoodFrenzy.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

    }

}
