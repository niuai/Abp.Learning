using Lycoris.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lycoris.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class LycorisPageModel : AbpPageModel
    {
        protected LycorisPageModel()
        {
            LocalizationResourceType = typeof(LycorisResource);
        }
    }
}