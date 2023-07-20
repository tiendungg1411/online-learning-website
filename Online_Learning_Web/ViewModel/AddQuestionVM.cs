namespace Online_Learning_Web.ViewModel
{
    public class AddQuestionVM
    {
        public int LessonID { get; set; }
        public string Content { get; set; }
        public List<string> Answer { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explain { get; set; }
    }
}
