using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinDomainSharedModule)
    )]
    public class JiabinApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            JiabinDtoExtensions.Configure();
        }
    }
}
