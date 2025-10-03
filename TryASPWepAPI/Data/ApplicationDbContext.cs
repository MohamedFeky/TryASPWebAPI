using Microsoft.EntityFrameworkCore;
using TryASPWepAPI.Models;

namespace TryASPWepAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
    }
}
