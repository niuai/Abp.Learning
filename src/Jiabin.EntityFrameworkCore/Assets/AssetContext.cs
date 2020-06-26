using Jiabin.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jiabin.Assets
{
    public class AssetContext : JiabinDbContext
    {
        public DbSet<Asset> Assets { get; set; }

        public DbSet<AssetRecord> AssetRecords { get; set; }

        public AssetContext(DbContextOptions<JiabinDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
