using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

namespace Lycoris.Assets
{
    public class AssetEventHandler :
        ILocalEventHandler<EntityCreatingEventData<Asset>>,
        ILocalEventHandler<EntityUpdatingEventData<Asset>>,
        ILocalEventHandler<EntityUpdatedEventData<Asset>>,
        ILocalEventHandler<EntityDeletingEventData<Asset>>,
        ITransientDependency
    {
        private readonly IAssetRepository _assetRepo;

        public AssetEventHandler(IAssetRepository assetRepo)
        {
            _assetRepo = assetRepo;
        }

        public async Task HandleEventAsync(EntityCreatingEventData<Asset> eventData)
        {
            var entity = eventData.Entity;

            await Task.CompletedTask;
        }

        public async Task HandleEventAsync(EntityUpdatingEventData<Asset> eventData)
        {
            var entity = eventData.Entity;
            var dbAsset = await _assetRepo.FindAsync(entity.Id);

            var dbContext = await _assetRepo.GetDbContextAsync();

            foreach (var entry in dbContext.Entry(dbAsset).Properties)
            {
                Console.WriteLine(
                    $"Property '{entry.Metadata.Name}'" +
                    $" is {(entry.IsModified ? "modified" : "not modified")} " +
                    $"Current value: '{entry.CurrentValue}' " +
                    $"Original value: '{entry.OriginalValue}'");
            }

            var changeInfo = dbContext.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified).ToList();

            await Task.CompletedTask;
        }

        public async Task HandleEventAsync(EntityUpdatedEventData<Asset> eventData)
        {
            var entity = eventData.Entity;

            await Task.CompletedTask;
        }

        public async Task HandleEventAsync(EntityDeletingEventData<Asset> eventData)
        {
            await Task.CompletedTask;
        }
    }
}
