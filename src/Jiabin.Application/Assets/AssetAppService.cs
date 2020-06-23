using Jiabin.Assets.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jiabin.Assets
{
    public class AssetAppService :
        CrudAppService<Asset, AssetDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAssetDto, CreateUpdateAssetDto>,
        IAssetAppService
    {
        private readonly IAssetRepository _repository;

        public AssetAppService(IAssetRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
