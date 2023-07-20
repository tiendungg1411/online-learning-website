using Online_Learning_Web.Models;

namespace Online_Learning_Web.ViewModel
{
    public class DoingQuestionVM
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
        public CorrectAnswer CorrectAnswer { get; set; }
    }
}
