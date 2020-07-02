using Jiabin.Asset;
using Jiabin.EntityFrameworkCore;
using Jiabin.Order;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jiabin.Web
{
    [DependsOn(
        typeof(JiabinHttpApiModule),
        typeof(JiabinApplicationModule),
        typeof(JiabinApplicationOrderModule),
        typeof(JiabinEntityFrameworkAssetAssetModule),
        typeof(JiabinEntityFrameworkCoreOrderModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule)
        )]
    public class JiabinWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureDatabase(context);
            ConfigureAutoMapper();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureDatabase(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JiabinDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions
                        .UseMySql(context.Services.GetConfiguration().GetConnectionString("Default"), mySqlOptions =>
                            mySqlOptions.ServerVersion(new Version(5, 6, 0), ServerType.MySql));
                });
            });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<JiabinWebModule>();

            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(JiabinApplicationModule).Assembly);
                options.ConventionalControllers.Create(typeof(JiabinApplicationOrderModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Jiabin API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }

            app.UseRouting();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Jiabin API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
