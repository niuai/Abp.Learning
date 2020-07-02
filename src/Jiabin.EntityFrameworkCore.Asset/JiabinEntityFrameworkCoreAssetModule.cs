using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jiabin.Asset
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule))]
    public class JiabinEntityFrameworkAssetAssetModule : AbpModule
    {
    }
}
