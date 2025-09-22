using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Persistence.Models
{
    public class UserdbContext : DbContext
    {
        public UserdbContext() { }

        public UserdbContext(DbContextOptions<UserdbContext> options)
        : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<History> histories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=UserDatabase;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.HasIndex(u => u.UserGmail)
                    .IsUnique();

                entity.Property(u => u.UserGmail)
                    .IsRequired();

                entity.Property(u => u.Password)
                .IsRequired();

                entity.Property(u => u.IndexName)
                    .IsRequired();

                entity.Property(u => u.ApiKey)
                      .IsRequired();

                entity.HasMany(u => u.histories)
                    .WithOne(h => h.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(h => h.HistoryId);
            });
        }
    }
}
