using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Web.Models
{
    public class AppUserQuestions
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string AppUsersId { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey("Question")]
        public int QuestionsId { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
        public bool TrueOrFalse { get; set; }
    }
}
