using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataAccess.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Rubric> Rubric { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Article> Article { get; set; }
    }
}
