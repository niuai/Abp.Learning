using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Lycoris.Data
{
    /* This is used if database provider does't define
     * ILycorisDbSchemaMigrator implementation.
     */
    public class NullLycorisDbSchemaMigrator : ILycorisDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}