using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Jiabin.Controllers
{
    /* Inherit your controllers from this class.
     */
    [Route("api/[controller]")]
    [ApiController]
    public abstract class JiabinController : AbpController
    {
        protected JiabinController()
        {
            //LocalizationResource = typeof(JiabinResource);
        }
    }
}