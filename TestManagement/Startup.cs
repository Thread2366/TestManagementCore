using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore;
using TestManagementCore.AdminAuth;
using TestManagementCore.Api;
using TestManagementCore.Integration;
using TestManagementCore.Security;
using TestManagementCore.Testing;

namespace TestManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddCors()
                .Configure<ServiceSettings>(Configuration.GetSection("ServiceSettings"))
                .AddSingleton(pr => pr.GetService<IOptions<ServiceSettings>>().Value)
                .AddSingleton<IIntegrationService, IntegrationService>()
                .AddSingleton<IAdminAuthService, AdminAuthService>()
                .AddSingleton<IApiService, ApiService>()
                .AddSingleton<ISecurityService, SecurityService>()
                .AddSingleton<TestCaseService>()
                .AddSingleton<TestContainerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.WithOrigins("*").AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
