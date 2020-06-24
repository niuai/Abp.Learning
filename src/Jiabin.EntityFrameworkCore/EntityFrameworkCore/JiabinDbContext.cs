using Jiabin.Assets;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jiabin.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class JiabinDbContext : AbpDbContext<JiabinDbContext>
    {
        public DbSet<Asset> Assets { get; set; }

        public JiabinDbContext(DbContextOptions<JiabinDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureJiabin();
        }
    }
}
