using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Web.Models
{
    public class RouteType
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [DataType("nvarchar(500)")]
        public string Name { get; set; }
        [DataType("nvarchar(500)")]
        public string Image { get; set; }
        [DataType("nvarchar(5000)")]
        public string Description1 { get; set; }
        [DataType("nvarchar(5000)")]
        public string Description2 { get; set; }
        public int Status { get; set; }
    }
}


