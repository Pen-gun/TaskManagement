using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Models;

namespace TaskManagementv2.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Taasks> TaskDb{ get; set; }
    }
}
