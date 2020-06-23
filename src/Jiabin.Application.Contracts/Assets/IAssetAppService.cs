using Jiabin.Assets.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jiabin.Assets
{
    public interface IAssetAppService :
        ICrudAppService<
            AssetDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAssetDto,
            CreateUpdateAssetDto>
    {
    }
}
