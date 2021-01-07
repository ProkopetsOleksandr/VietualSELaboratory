using System.Collections.Generic;

namespace Domain
{
    public class SaveAnswerViewModel
    {
        public int QuestionId { get; set; }
        public List<int> Correct { get; set; }
        public List<int> Incorrect { get; set; }
    }
}
