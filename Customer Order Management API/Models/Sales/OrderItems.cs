using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer_Order_Management_API.Models.Sales
{
    [Table("order_items", Schema = "sales")]
    public class OrderItems
    {
        [Key]
        public int order_id { get; set; }

        [Key]
        public int ?item_id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal List_Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Discount { get; set; } = 0;
    }
}
