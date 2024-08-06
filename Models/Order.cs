using FoodFrenzy.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFrenzy.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Bill Amount is required.")]
        [IndianCurrency(ErrorMessage = "Invalid Indian Currency format.")]
        [Display(Name = "Bill Amount")]
        public decimal BillAmount { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
