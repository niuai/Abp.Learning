using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
                .UseMySql(configuration.GetConnectionString("Default"), mySqlOptions =>
                            mySqlOptions.ServerVersion(new Version(5, 6, 0), ServerType.MySql));

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
