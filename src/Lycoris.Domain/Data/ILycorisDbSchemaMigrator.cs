using System.Threading.Tasks;

namespace Lycoris.Data
{
    public interface ILycorisDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
