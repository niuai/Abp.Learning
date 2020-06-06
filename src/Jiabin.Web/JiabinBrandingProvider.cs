using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Jiabin.Web
{
    [Dependency(ReplaceServices = true)]
    public class JiabinBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Jiabin";
    }
}
