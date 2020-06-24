using Jiabin.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jiabin.Assets
{
    public class AssetContext : JiabinDbContext
    {
        public DbSet<AssetRecord> AssetRecords { get; set; }

        public AssetContext(DbContextOptions<JiabinDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssetRecord>(b =>
            {
                b.ToTable(JiabinConsts.DbTablePrefix + "AssetRecords", JiabinConsts.DbSchema);
                b.Ignore(p => p.ExtraProperties);
            });
        }
    }
}
