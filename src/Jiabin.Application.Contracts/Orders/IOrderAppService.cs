using Volo.Abp.Application.Services;

namespace Jiabin.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        string Get();
    }
}
