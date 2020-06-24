using Jiabin.Assets;
using System.Linq;
using Volo.Abp.Application.Services;

namespace Jiabin.Orders
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IAssetRepository _assetRepo;

        private readonly IOrderRepository _orderRepo;

        public OrderAppService(IAssetRepository assetRepo, IOrderRepository orderRepo)
        {
            _assetRepo = assetRepo;
            _orderRepo = orderRepo;
        }

        public string Get()
        {
            var t1 = _assetRepo.ToList();
            var t2 = _orderRepo.ToList();

            return "Hello World!";
        }
    }
}
