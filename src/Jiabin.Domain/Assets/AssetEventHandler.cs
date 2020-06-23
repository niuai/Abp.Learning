using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Jiabin.Assets
{
    public class AssetEventHandler :
        ILocalEventHandler<EntityCreatingEventData<Asset>>,
        ILocalEventHandler<EntityUpdatingEventData<Asset>>,
        ILocalEventHandler<EntityDeletingEventData<Asset>>,
        ITransientDependency
    {
        private readonly IAssetRepository _db;

        public AssetEventHandler(IAssetRepository db)
        {
            _db = db;
        }

        public async Task HandleEventAsync(EntityCreatingEventData<Asset> eventData)
        {
            var entity = eventData.Entity;

            entity.TempFileBytes = entity.FileBytes;
            entity.FileBytes = null;

            await Task.CompletedTask;
        }

        public async Task HandleEventAsync(EntityUpdatingEventData<Asset> eventData)
        {
            var entity = eventData.Entity;

            entity.FileBytes = null;

            await Task.CompletedTask;
        }

        public async Task HandleEventAsync(EntityDeletingEventData<Asset> eventData)
        {
            await Task.CompletedTask;
        }
    }
}
