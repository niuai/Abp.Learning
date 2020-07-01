using Jiabin.ObjectExtending;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinDomainSharedModule),
        typeof(AbpDddDomainModule)
        )]
    public class JiabinDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            JiabinDomainObjectExtensions.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
