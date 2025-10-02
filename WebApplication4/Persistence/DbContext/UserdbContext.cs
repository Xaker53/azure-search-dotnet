using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.Extensions.Options;
using Persistence.Configuration;
using Core.Entities;

namespace Persistence.Models
{
    public class UserdbContext: DbContext
    {
        private readonly IOptions<AuthorizationOptions> authOption;
        public UserdbContext() { }

        public UserdbContext(DbContextOptions<UserdbContext> options, IOptions<AuthorizationOptions> authOption = null)
        : base(options) {
            this.authOption = authOption;
        }

        public DbSet<User> users { get; set; }
        public DbSet<History> histories { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }


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

                entity.Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasIndex(u => u.UserGmail)
                    .IsUnique();

                entity.Property(u => u.UserGmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.IndexName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.ApiKey)
                      .IsRequired();

                entity.Property(u => u.Salt).IsRequired().HasMaxLength(50);

                entity.HasMany(u => u.histories)
                    .WithOne(h => h.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(h => h.HistoryId);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserdbContext).Assembly);
            if (authOption != null)
            {
                modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOption.Value));
            }
            
        }
    }
}
