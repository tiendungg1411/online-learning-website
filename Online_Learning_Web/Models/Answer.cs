using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class Answer
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
