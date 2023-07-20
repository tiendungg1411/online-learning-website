using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class CourseRequirement
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType("nvarchar(1000)")]
        public string Content { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
