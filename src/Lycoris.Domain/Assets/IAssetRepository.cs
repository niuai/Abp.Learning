using System;
using Volo.Abp.Domain.Repositories;

namespace Lycoris.Assets
{
    public interface IAssetRepository : IRepository<Asset, Guid>
    {
    }
}
