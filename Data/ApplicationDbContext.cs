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

        public  DbSet<Station> Stations { get; set; }
        public  DbSet<Card_Info> Cards { get; set; }
        public  DbSet<Train> Trains { get; set; }
        public  DbSet<Class> Classes { get; set; }
        public  DbSet<Trip> Trips { get; set; }
        public  DbSet<Ticket> Tickets { get; set; }
        public  DbSet<ClassTrip> ClassTrips { get; set; }
    }
}
