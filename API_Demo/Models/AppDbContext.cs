using Microsoft.EntityFrameworkCore;

namespace API_Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
