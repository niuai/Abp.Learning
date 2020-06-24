using Jiabin.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.IO;

namespace Jiabin.Assets
{
    public class AssetContextFactory : IDesignTimeDbContextFactory<AssetContext>
    {
        public AssetContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<JiabinDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"), mySqlOptions =>
                            mySqlOptions.ServerVersion(new Version(5, 6, 0), ServerType.MySql));

            return new AssetContext(builder.Options);
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
