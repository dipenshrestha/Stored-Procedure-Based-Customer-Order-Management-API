using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.Productions
{
    [Table("stocks", Schema = "production")]
    public class Stocks
    {
        [Key, Column(Order = 0)]
        public int? Store_Id { get; set; }

        [Key, Column(Order = 1)]
        public int? Product_Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
