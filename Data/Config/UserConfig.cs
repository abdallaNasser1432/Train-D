using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Train_D.Models;

namespace Train_D.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "Users");
            builder.Property(u => u.UserName)
                .UseCollation("SQL_Latin1_General_CP1_CS_AS");

            builder.Property(u => u.Email)
                .UseCollation("SQL_Latin1_General_CP1_CS_AS")
                .IsRequired();

            builder.Property(u => u.NormalizedUserName)
                .UseCollation("SQL_Latin1_General_CP1_CS_AS")
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

        }
    }
}
