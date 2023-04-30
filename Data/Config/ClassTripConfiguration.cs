using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class ClassTripConfiguration : IEntityTypeConfiguration<ClassTrip>
    {
        public void Configure(EntityTypeBuilder<ClassTrip> builder)
        {
            builder.Property(p => p.ClassPrice)
                .HasColumnType("money");

            builder.HasKey(t => new { t.TrainId, t.TripId, t.ClassName });

            builder
                .HasOne(t => t.Trip)
                .WithMany(c => c.ClassTrips)
                .HasForeignKey(t => t.TripId);

            builder
                .HasOne(c => c.Class)
                .WithMany(c => c.ClassTrips)
                .HasForeignKey(t => new { t.TrainId, t.ClassName })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
