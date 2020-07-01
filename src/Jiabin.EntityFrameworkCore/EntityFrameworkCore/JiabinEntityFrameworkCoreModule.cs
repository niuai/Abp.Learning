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
            
        }
    }
}
