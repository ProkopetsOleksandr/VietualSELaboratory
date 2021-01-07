namespace Domain.RDBMS.Entities
{
    public class UserAnswers : IEntityBase
    {
        public int Id { get; set; }
        public int StatisticsId { get; set; }
        public int QuestionId { get; set; }
        public string CorrectAnswers { get; set; }
        public string IncorrectAnswers { get; set; }

        public virtual Question Question { get; set; }
        public virtual Statistics Statistics { get; set; }
    }
}