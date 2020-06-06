using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Jiabin.Data
{
    /* This is used if database provider does't define
     * IJiabinDbSchemaMigrator implementation.
     */
    public class NullJiabinDbSchemaMigrator : IJiabinDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}