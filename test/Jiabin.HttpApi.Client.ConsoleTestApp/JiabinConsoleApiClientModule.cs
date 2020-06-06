using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jiabin.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(JiabinHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class JiabinConsoleApiClientModule : AbpModule
    {
        
    }
}
