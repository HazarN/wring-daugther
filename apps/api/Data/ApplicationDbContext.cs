using Microsoft.EntityFrameworkCore;

using api.Entities;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Mock Data
            modelBuilder.Entity<User>().HasData(
                new()
                {
                    Id = 1,
                    Username = "HazarN",
                    Email = "hazar@example.com",
                    PasswordHashed = "hashed_password_1",
                    CreatedAt = new DateTime(2001, 11, 6, 0, 0, 0, DateTimeKind.Utc),
                    IsAdmin = true
                },
                new()
                {
                    Id = 2,
                    Username = "JohnD",
                    Email = "john@example.com",
                    PasswordHashed = "hashed_password_2",
                    CreatedAt = new DateTime(2001, 11, 6, 0, 0, 0, DateTimeKind.Utc),
                    IsAdmin = false
                },
                new()
                {
                    Id = 3,
                    Username = "JaneD",
                    Email = "jane@example.com",
                    PasswordHashed = "hashed_password_3",
                    CreatedAt = new DateTime(2001, 11, 6, 0, 0, 0, DateTimeKind.Utc),
                    IsAdmin = false
                }
            );
        }
    }
}
