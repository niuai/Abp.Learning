using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinApplicationContractsModule)
        )]
    public class JiabinHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
