using Lycoris.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lycoris.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LycorisController : AbpController
    {
        protected LycorisController()
        {
            LocalizationResource = typeof(LycorisResource);
        }
    }
}