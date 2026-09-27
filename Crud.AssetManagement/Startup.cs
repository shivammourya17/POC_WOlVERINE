using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.Extensions;
using Crud.AssetManagement.Infrastructure.Extensions;
using Crud.AssetManagement.Integration.Extensions;
using Crud.AssetManagement.Queries.Extensions;

namespace Crud.AssetManagement
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServices();

            // Explicit assemblies: scanning AppDomain.CurrentDomain.GetAssemblies() misses the
            // Commands assembly, which is no longer loaded this early now that its only startup
            // reference lives in ConfigureWolverine.
            services.AddAutoMapper(_ => { },
                typeof(Startup).Assembly,
                typeof(Crud.AssetManagement.Commands.Mapper.AssetMapper).Assembly);

            services.AddInfrastructureServices();
            services.AddIntegrationServices();
        }

        // Replaces services.AddMediatR(...); called from Program via builder.Host.UseWolverine.
        public void ConfigureWolverine(WolverineOptions options)
        {
            options.AddCommandHandlers();
            options.AddQueryHandlers();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.MapControllers();
        }
    }
}
