using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Jiabin
{
    public class JiabinWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<JiabinWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}