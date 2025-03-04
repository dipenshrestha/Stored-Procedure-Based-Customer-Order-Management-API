using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Order_Management_API.Models.sales
{
    [Table("customers", Schema = "sales")]
    public class Customers
    {
        //note that the name here should match the names in database table column names
        //otherwise there will be errors while mapping to database table column
        //The name can be written in upper or lowercase it doesnot matters 
        //i.e. PHONE is same as phone
        [Key]
        public int? customer_id { get; set; }

        [Required]
        [StringLength(255)]
        public string first_name { get; set; }

        [Required]
        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(25)]
        public string phone { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string email { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(25)]
        public string state { get; set; }
    }
}
