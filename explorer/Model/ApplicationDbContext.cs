using Microsoft.EntityFrameworkCore;

namespace explorer.Model
{
    public class ApplicationDbContext : DbContext
    {
            
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}