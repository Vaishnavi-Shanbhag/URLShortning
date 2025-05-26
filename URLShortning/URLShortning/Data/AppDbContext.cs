using Microsoft.EntityFrameworkCore;
using URLShortning.Models;

namespace URLShortning.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UrlMapping> UrlMappings { get; set; }
    }
}
