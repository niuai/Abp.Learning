using Jiabin.Assets;
using Jiabin.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Jiabin.EntityFrameworkCore
{
    public static class JiabinDbContextModelCreatingExtensions
    {
        public static void ConfigureJiabin(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Asset>(b =>
            {
                b.ToTable(JiabinConsts.DbTablePrefix + "Assets", JiabinConsts.DbSchema);
                b.Ignore(p => p.ExtraProperties);
            });

            builder.Entity<AssetRecord>(b =>
            {
                b.ToTable(JiabinConsts.DbTablePrefix + "AssetRecords", JiabinConsts.DbSchema);
                b.Ignore(p => p.ExtraProperties);
            });

            builder.Entity<Order>(b =>
            {
                b.ToTable(JiabinConsts.DbTablePrefix + "Orders", JiabinConsts.DbSchema);
                b.Ignore(p => p.ExtraProperties);
            });
        }
    }
}