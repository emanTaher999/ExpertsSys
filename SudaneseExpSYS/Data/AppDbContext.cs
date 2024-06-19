using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SudaneseExpSYS.Models;
using System.Reflection.Emit;

namespace SudaneseExpSYS.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Filed> fileds { get; set; }
        public DbSet<State> states { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName="admin",
                ConcurrencyStamp=Guid.NewGuid().ToString(),
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "user",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }

            );

            base.OnModelCreating(builder);
        }
        
    }
}
