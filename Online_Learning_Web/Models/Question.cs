using Online_Learning_Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class Question
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [DataType("nvarchar(10000)")]
        public string Content { get; set; }
        [DataType("nvarchar(1000)")]
        public string explain { get; set; }
        [ForeignKey("Lesson")]
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
