using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Lycoris.EntityFrameworkCore
{
    [DependsOn(
        typeof(LycorisEntityFrameworkCoreModule)
        )]
    public class LycorisEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LycorisMigrationsDbContext>();
        }
    }
}
