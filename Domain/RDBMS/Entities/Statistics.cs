using System;
using System.Collections.Generic;

namespace Domain.RDBMS.Entities
{
    public class Statistics : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public double Grade { get; set; }
        public DateTime ExecutionDate { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual List<UserAnswers> UserAnswers { get; set; }
    }
}
