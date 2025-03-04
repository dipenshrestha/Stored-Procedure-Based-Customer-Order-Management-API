using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.Productions
{
    [Table("categories", Schema = "production")]
    public class Categories
    {
        [Key]
        public int? Category_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Category_Name { get; set; }
    }
}
