using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jiabin.Order
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule))]
    public class JiabinEntityFrameworkCoreOrderModule : AbpModule
    {
    }
}
