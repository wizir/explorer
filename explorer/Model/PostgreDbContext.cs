using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace explorer.Model
{
    public class PostgreDbContext<T> : DbContext
        where T: class
    {
        private readonly IConfiguration _configuration;
        public PostgreDbContext(IConfiguration configuration, DbContextOptions<PostgreDbContext<T>> options) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("psql"));
        }

        public DbSet<T> Items { get; set; }
    }
}