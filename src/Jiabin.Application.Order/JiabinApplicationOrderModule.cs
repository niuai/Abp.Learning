using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinDomainModule),
        typeof(JiabinApplicationContractsModule)
        )]
    public class JiabinApplicationOrderModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<JiabinApplicationOrderModule>();
            });
        }
    }
}
