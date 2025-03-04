using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.Productions
{
    [Table("products", Schema = "production")]
    public class Products
    {
        [Key]
        public int? Product_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Product_Name { get; set; }

        [Required]
        public int Brand_Id { get; set; }

        [Required]
        public int Category_Id { get; set; }

        [Required]
        public short Model_Year { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal List_Price { get; set; }
    }
}
