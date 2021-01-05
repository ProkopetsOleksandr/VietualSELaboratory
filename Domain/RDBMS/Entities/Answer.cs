namespace Domain.RDBMS.Entities
{
    public class Answer : IEntityBase
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
