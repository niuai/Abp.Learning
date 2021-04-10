using Volo.Abp.Modularity;

namespace Lycoris
{
    [DependsOn(
        typeof(LycorisApplicationModule),
        typeof(LycorisDomainTestModule)
        )]
    public class LycorisApplicationTestModule : AbpModule
    {

    }
}