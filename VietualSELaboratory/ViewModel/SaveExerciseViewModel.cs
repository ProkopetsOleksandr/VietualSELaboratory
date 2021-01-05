using System.Collections.Generic;
using Domain;
using Domain.RDBMS.Entities;

namespace VietualSELaboratory.ViewModel
{
    public class SaveExerciseViewModel
    {
        public Exercise Exercise { get; set; }

        public List<QuestionViewModel> QuestionViewModels { get; set; }
    }
}
