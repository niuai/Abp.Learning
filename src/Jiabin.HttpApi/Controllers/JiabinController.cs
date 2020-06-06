using Jiabin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jiabin.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class JiabinController : AbpController
    {
        protected JiabinController()
        {
            LocalizationResource = typeof(JiabinResource);
        }
    }
}