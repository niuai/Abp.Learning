using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lycoris.Data;
using Volo.Abp.DependencyInjection;

namespace Lycoris.EntityFrameworkCore
{
    public class EntityFrameworkCoreLycorisDbSchemaMigrator
        : ILycorisDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLycorisDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LycorisMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LycorisMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}