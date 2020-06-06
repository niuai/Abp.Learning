using System.Threading.Tasks;

namespace Jiabin.Data
{
    public interface IJiabinDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
