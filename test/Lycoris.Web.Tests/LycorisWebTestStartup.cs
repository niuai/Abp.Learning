using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Lycoris
{
    public class LycorisWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<LycorisWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}