using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFrenzy.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string? ReviewPoints { get; set; }

        public string Comments { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }


    }
}
