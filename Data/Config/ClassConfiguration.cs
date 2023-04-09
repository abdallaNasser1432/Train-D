using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Train_D.Models;


namespace Train_D.Data.Config
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder
                .HasKey(p => new { p.TrainId, p.ClassName });
        }
    }
}
