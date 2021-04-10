using Lycoris.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lycoris
{
    [DependsOn(
        typeof(LycorisEntityFrameworkCoreTestModule)
        )]
    public class LycorisDomainTestModule : AbpModule
    {

    }
}