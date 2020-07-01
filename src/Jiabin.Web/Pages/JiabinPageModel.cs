using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jiabin.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class JiabinPageModel : AbpPageModel
    {
        protected JiabinPageModel()
        {
            //LocalizationResourceType = typeof(JiabinResource);
        }
    }
}