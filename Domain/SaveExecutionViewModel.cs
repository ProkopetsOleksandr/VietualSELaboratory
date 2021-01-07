using System.Collections.Generic;

namespace Domain
{
    public class SaveExecutionViewModel
    {
        public int ExerciseId { get; set; }
        public List<SaveAnswerViewModel> Answers { get; set; }
    }
}
