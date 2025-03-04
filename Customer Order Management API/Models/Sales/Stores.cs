using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.Sales
{
    [Table("stores", Schema = "sales")]
    public class Stores
    {
        [Key]
        public int? Store_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Store_Name { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255)]
        public string Street { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(5)]
        public string Zip_Code { get; set; }
    }
}
