namespace Domain
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string[] Correct { get; set; }
        public string[] Incorrect { get; set; }
    }
}
