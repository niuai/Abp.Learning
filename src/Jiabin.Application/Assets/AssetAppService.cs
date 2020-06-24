using Jiabin.Assets.Dtos;
using Jiabin.Orders;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jiabin.Assets
{
    public class AssetAppService :
        CrudAppService<Asset, AssetDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAssetDto, CreateUpdateAssetDto>,
        IAssetAppService
    {
        private readonly IAssetRepository _assetRepo;

        private readonly IOrderRepository _orderRepo;

        public AssetAppService(IAssetRepository assetRepo, IOrderRepository orderRepo) : base(assetRepo)
        {
            _assetRepo = assetRepo;
            _orderRepo = orderRepo;
        }
    }
}
