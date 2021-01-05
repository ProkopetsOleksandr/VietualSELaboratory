using System.Collections.Generic;
using Domain.RDBMS.Entities;

namespace VietualSELaboratory.ViewModel
{
    public class ExerciseViewViewModel
    {
        public Exercise Exercise { get; set; }
        public List<Question> Questions { get; set; }
    }
}
