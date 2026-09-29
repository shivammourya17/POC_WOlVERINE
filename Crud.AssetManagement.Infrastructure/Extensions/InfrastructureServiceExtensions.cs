using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Contracts.Category;
using Crud.AssetManagement.Infrastructure.Repositories.Asset;
using Crud.AssetManagement.Infrastructure.Repositories.Category;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ISessionFactory>(sp =>
                SessionFactoryBuilder.Build(sp.GetRequiredService<IConfiguration>().GetConnectionString("AssetManagementDb")));

            // One session per scope. Wolverine opens a scope per message, so each command
            // handler gets its own session shared by the repository and the unit of work.
            services.AddScoped<ISession>(sp => sp.GetRequiredService<ISessionFactory>().OpenSession());

            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetUnitOfWork, AssetUnitOfWork>();

            services.AddScoped<IAssetCategoryRepository, AssetCategoryRepository>();
            services.AddScoped<IAssetCategoryUnitOfWork, AssetCategoryUnitOfWork>();

            // Backs the raw-SQL QueryBuilder used by the Queries project.
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
