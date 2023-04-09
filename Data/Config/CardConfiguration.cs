using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class CardConfiguration : IEntityTypeConfiguration<Card_Info>
    {
        public void Configure(EntityTypeBuilder<Card_Info> builder)
        {
            builder.ToTable("Card_Info")
                .HasKey(c => c.CardNumber);

            builder.Property(t => t.ExpDate)
                .HasColumnType("date");

            builder
                .HasOne(u => u.User)
                .WithOne(c => c.Card)
                .HasForeignKey<Card_Info>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
