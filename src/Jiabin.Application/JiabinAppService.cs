using System;
using System.Collections.Generic;
using System.Text;
using Jiabin.Localization;
using Volo.Abp.Application.Services;

namespace Jiabin
{
    /* Inherit your application services from this class.
     */
    public abstract class JiabinAppService : ApplicationService
    {
        protected JiabinAppService()
        {
            LocalizationResource = typeof(JiabinResource);
        }
    }
}
