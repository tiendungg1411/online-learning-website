using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Web.Models
{
    public class CorrectAnswer
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [DataType("nvarchar(10000)")]
        public string Content { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}


