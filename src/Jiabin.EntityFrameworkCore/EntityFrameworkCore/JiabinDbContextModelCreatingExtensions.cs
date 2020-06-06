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

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(JiabinConsts.DbTablePrefix + "YourEntities", JiabinConsts.DbSchema);

            //    //...
            //});
        }
    }
}