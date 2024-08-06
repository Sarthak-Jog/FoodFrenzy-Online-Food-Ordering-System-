using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFrenzy.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int CartId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { 
            get
            {
                return Products.Sum(p => p.ProductPrice);
            }
        }
    }
}
