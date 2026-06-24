using Microsoft.EntityFrameworkCore;
using FreelanceHub.Models;
namespace FreelanceHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
