using Microsoft.EntityFrameworkCore;

namespace CodeFirst_MySql.Models
{
    public class DemoContext: DbContext
    {

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
