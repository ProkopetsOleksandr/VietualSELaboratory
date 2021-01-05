using System.Collections.Generic;
using Domain.RDBMS.Entities;

namespace VietualSELaboratory.ViewModel
{
    public class ExerciseViewModel
    {
        public IEnumerable<Level> Levels { get; set; }
        public Exercise Exercise { get; set; }
    }
}
