using Lycoris.Assets;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lycoris.EntityFrameworkCore
{
    public static class LycorisDbContextModelCreatingExtensions
    {
        public static void ConfigureLycoris(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Asset>(b =>
            {
                b.ToTable(LycorisConsts.DbTablePrefix + "Assets", LycorisConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
            });
        }
    }
}