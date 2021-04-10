using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lycoris.Assets
{
    public class AssetAppService : LycorisAppService, IAssetAppService
    {
        private readonly IAssetRepository _assetRepo;

        public AssetAppService(IAssetRepository assetRepo)
        {
            _assetRepo = assetRepo;
        }

        public async Task<Asset> Create()
        {
            var newAsset = new Asset
            {
                Name = $"asset-{DateTime.Now.Ticks}",
                Description = "des",
                AttachUrl = "attach",
            };

            await _assetRepo.InsertAsync(newAsset);

            return newAsset;
        }

        public async Task<IEnumerable<Asset>> Get()
        {
            return await _assetRepo.ToListAsync();
        }

        public async Task<Asset> Update()
        {
            var asset = await _assetRepo.FirstOrDefaultAsync();
            var dbContext = await _assetRepo.GetDbContextAsync();

            asset.AttachUrl = $"attach-{DateTime.Now.Ticks}";

            foreach (var entry in dbContext.Entry(asset).Properties)
            {
                Console.WriteLine(
                    $"Property '{entry.Metadata.Name}'" +
                    $" is {(entry.IsModified ? "modified" : "not modified")} " +
                    $"Current value: '{entry.CurrentValue}' " +
                    $"Original value: '{entry.OriginalValue}'");
            }

            return asset;
        }
    }
}
