using Microsoft.EntityFrameworkCore;
using test_dot.Data.Entities;

namespace test_dot.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> context) : base(context)
        {

        }


        public DbSet<Students> Students { get; set; }
    }
}
