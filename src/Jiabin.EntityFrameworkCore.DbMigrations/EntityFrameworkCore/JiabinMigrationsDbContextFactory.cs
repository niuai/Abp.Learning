using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jiabin.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class JiabinMigrationsDbContextFactory : IDesignTimeDbContextFactory<JiabinMigrationsDbContext>
    {
        public JiabinMigrationsDbContext CreateDbContext(string[] args)
        {
            JiabinEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<JiabinMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new JiabinMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
