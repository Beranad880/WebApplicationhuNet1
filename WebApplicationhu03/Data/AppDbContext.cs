using Microsoft.EntityFrameworkCore;
using WebApplicationhu03.Models;

namespace WebApplicationhu03.Models
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!; 
    }
}
