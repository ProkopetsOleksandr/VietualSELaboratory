using System;

namespace Domain.RDBMS.Entities
{
    public class Statistics : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
        public double Grade { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}
