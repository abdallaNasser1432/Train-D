using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder
                .HasMany(c => c.Classes)
                .WithOne(t => t.Train)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
