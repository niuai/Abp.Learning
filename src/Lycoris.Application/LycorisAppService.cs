using System;
using System.Collections.Generic;
using System.Text;
using Lycoris.Localization;
using Volo.Abp.Application.Services;

namespace Lycoris
{
    /* Inherit your application services from this class.
     */
    public abstract class LycorisAppService : ApplicationService
    {
        protected LycorisAppService()
        {
            LocalizationResource = typeof(LycorisResource);
        }
    }
}
