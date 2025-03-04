using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.Productions
{
    [Table("brands", Schema = "production")]
    public class Brands
    {
        [Key]
        public int? Brand_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Brand_Name { get; set; }
    }
}
