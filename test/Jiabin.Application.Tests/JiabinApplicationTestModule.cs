using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinApplicationModule),
        typeof(JiabinDomainTestModule)
        )]
    public class JiabinApplicationTestModule : AbpModule
    {

    }
}