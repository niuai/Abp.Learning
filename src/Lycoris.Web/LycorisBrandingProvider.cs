using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Lycoris.Web
{
    [Dependency(ReplaceServices = true)]
    public class LycorisBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Lycoris";
    }
}
