using Jiabin.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jiabin.Assets
{
    public class AssetRepository : EfCoreRepository<AssetContext, Asset, Guid>, IAssetRepository
    {
        public AssetRepository(IDbContextProvider<AssetContext> dbContextProvider) : base(dbContextProvider) { }
    }
}
