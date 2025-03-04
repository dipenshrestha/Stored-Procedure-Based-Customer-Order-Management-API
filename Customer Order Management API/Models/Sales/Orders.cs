using Customer_Order_Management_API.Models.sales;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer_Order_Management_API.Models.Sales
{
    [Table("orders", Schema = "sales")]
    public class Orders
    {
        [Key]
        public int? Order_Id { get; set; }

        public int Customer_Id { get; set; }

        [Required]
        public byte Order_Status { get; set; } // 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed

        [Required]
        public DateTime Order_Date { get; set; }

        [Required]
        public DateTime Required_Date { get; set; }

        public DateTime? Shipped_Date { get; set; }

        [Required]
        public int Store_Id { get; set; }

        [Required]
        public int Staff_Id { get; set; }
    }
}
