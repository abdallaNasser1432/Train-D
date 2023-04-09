using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Train_D.Data.Config;
using Train_D.Models;

namespace Train_D.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);

            //Rename Identity Tables Names
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
        }

        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Card_Info> Cards { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ClassTrip> ClassTrips { get; set; }
    }
}
