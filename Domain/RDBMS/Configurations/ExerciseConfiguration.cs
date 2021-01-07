using Domain.RDBMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.RDBMS.Configurations
{
    public class ExerciseConfiguration: IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasMany<Statistics>()
                .WithOne(m => m.Exercise)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
