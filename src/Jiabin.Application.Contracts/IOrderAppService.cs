using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Jiabin
{
    public interface IOrderAppService : ITransientDependency
    {
        string Get();
    }
}
