using Online_Learning_Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class Chapter
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [DataType("nvarchar(500)")]
        public string Name { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}

