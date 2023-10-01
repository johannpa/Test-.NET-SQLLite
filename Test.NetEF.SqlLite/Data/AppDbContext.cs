using Microsoft.EntityFrameworkCore;
using Test.NetEF.SqlLite.Models;

namespace Test.NetEF.SqlLite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
