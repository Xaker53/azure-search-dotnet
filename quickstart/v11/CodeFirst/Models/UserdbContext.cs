using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class UserdbContext : DbContext
    {
        public UserdbContext() { }

        public UserdbContext(DbContextOptions<UserdbContext> options)
        :base (options) { }

        public DbSet<User> users { get; set; }
        public DbSet<History> histories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=UserDatabase;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
