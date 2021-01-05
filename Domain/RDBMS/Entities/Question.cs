using System.Collections.Generic;

namespace Domain.RDBMS.Entities
{
    public class Question : IEntityBase
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string Text { get; set; }
        public virtual List<Answer> Answers{ get; set; }
    }
}
