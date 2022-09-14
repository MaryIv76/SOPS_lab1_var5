using Microsoft.EntityFrameworkCore;

namespace lab1_var5.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
