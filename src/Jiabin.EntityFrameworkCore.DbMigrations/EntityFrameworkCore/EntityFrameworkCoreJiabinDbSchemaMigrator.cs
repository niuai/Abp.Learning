using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Jiabin.Data;
using Volo.Abp.DependencyInjection;

namespace Jiabin.EntityFrameworkCore
{
    public class EntityFrameworkCoreJiabinDbSchemaMigrator
        : IJiabinDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreJiabinDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the JiabinMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<JiabinMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}