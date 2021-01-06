using System.Collections.Generic;

namespace Domain.RDBMS.Entities
{
    public class Exercise: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
