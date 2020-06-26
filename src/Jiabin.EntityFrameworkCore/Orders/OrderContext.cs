using Jiabin.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jiabin.Orders
{
    public class OrderContext : JiabinDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<JiabinDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
