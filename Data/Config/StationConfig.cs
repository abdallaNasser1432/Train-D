using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class StationConfig : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(s => s.StationName);

            builder.Property(l => l.Latitude)
                .HasColumnType("DECIMAL(4,12)");
            builder.Property(l => l.Longitude)
                .HasColumnType("DECIMAL(4,12)");

            builder.Property(a => a.Address)
                .IsRequired();

            builder.Property(p => p.Phone)
                .IsRequired();

            builder.Property(p => p.StationInfo)
               .IsRequired();

            builder
                .HasMany(t => t.TripsStart)
                .WithOne(s => s.StationBegain)
                .HasForeignKey(t => t.StartStation)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.TripsEnd)
                .WithOne(s => s.StationEnd)
                .HasForeignKey(t => t.EndStaion)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
