using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer_Order_Management_API.Models.Sales
{
    [Table("staffs", Schema = "sales")]
    public class Staffs
    {
        [Key]
        public int? Staff_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [Required]
        public int Store_Id { get; set; }
    }
}
