using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Jiabin.EntityFrameworkCore
{
    [DependsOn(
        typeof(JiabinEntityFrameworkCoreModule)
        )]
    public class JiabinEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JiabinMigrationsDbContext>();
        }
    }
}
