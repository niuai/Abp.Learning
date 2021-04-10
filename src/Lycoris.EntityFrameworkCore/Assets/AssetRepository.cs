using Lycoris.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lycoris.Assets
{
    public class AssetRepository : EfCoreRepository<LycorisDbContext, Asset, Guid>, IAssetRepository
    {
        public AssetRepository(IDbContextProvider<LycorisDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
