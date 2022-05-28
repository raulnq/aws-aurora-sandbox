using Microsoft.EntityFrameworkCore;

namespace aws_aurora_sandbox_app
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}