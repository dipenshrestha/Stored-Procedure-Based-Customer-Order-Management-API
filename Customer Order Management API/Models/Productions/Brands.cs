using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Customer_Order_Management_API.Models.Productions
{
    [Table("brands", Schema = "production")]
    public class Brands
    {
        [Key]
        //need using System.Text.Json.Serialization; 
        // below annotation is used to send custom names to the client
        [JsonPropertyName("Id")]
        public int? Brand_Id { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("Name")]
        public string Brand_Name { get; set; }
    }
}
