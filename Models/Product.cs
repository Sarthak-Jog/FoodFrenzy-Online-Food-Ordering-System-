using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFrenzy.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCategory {  get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public bool IsAvailable { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductPicture { get; set; }
        public string? ReviewPoints { get; set; }

        [ForeignKey("Review")]
        public string? ReviewId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
