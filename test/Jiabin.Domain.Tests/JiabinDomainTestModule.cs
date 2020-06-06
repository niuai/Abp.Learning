using Jiabin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jiabin
{
    [DependsOn(
        typeof(JiabinEntityFrameworkCoreTestModule)
        )]
    public class JiabinDomainTestModule : AbpModule
    {

    }
}