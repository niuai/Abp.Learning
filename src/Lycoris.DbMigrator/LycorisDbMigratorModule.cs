using Lycoris.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Lycoris.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LycorisEntityFrameworkCoreDbMigrationsModule),
        typeof(LycorisApplicationContractsModule)
        )]
    public class LycorisDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
