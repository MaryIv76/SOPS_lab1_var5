using Microsoft.EntityFrameworkCore;

namespace lab1_var5.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<TrackRecord> TrackRecords { get; set; }    

        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
