using System;
using Volo.Abp.Domain.Repositories;

namespace Jiabin.Assets
{
    public interface IAssetRepository : IRepository<Asset, Guid>
    {
    }
}
