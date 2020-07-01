using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jiabin.EntityFrameworkCore
{
    [DependsOn(
        typeof(JiabinDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class JiabinEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            JiabinEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JiabinDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions
                        .UseMySql(context.Services.GetConfiguration().GetConnectionString("Default"), mySqlOptions =>
                            mySqlOptions.ServerVersion(new Version(5, 6, 0), ServerType.MySql));
                });
            });
        }
    }
}
