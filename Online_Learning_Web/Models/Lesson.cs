using Online_Learning_Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class Lesson
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [DataType("nvarchar(500)")]
        public string Name { get; set; }
        [DataType("nvarchar(10000)")]
        public string Content { get; set; }
        [DataType("nvarchar(500)")]
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public int NumOfLike { get; set; }
        [DataType("nvarchar(500)")]
        public string Type { get; set; }
        [ForeignKey("Chapter")]
        public int ChapterID { get; set; }
        public Chapter Chapter { get; set; }

    }
}
