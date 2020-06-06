using Jiabin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Jiabin.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(JiabinEntityFrameworkCoreDbMigrationsModule),
        typeof(JiabinApplicationContractsModule)
        )]
    public class JiabinDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
