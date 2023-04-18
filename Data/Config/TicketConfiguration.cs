using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(d => d.Date)
                .HasColumnType("date");

            builder.Property(a => a.Amount)
                .HasColumnType("money");

            builder.Property(p => p.PaymentId)
                .IsRequired();

            builder
                .HasOne(t => t.Trip)
                .WithMany(tk => tk.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.User)
                .WithMany(tk => tk.Tickets)
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
