using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Lycoris.EntityFrameworkCore
{
    public static class LycorisDbContextModelCreatingExtensions
    {
        public static void ConfigureLycoris(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LycorisConsts.DbTablePrefix + "YourEntities", LycorisConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}