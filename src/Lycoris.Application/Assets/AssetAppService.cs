using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

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
            var assets = await _assetRepo.ToListAsync();

            return assets;
        }

        [UnitOfWork]
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

            var changeInfo = dbContext.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified).ToList();

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
