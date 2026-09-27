using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Driver;
using Crud.AssetManagement.Infrastructure.Mappings.Asset;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Builds the single NHibernate ISessionFactory for the app from the Fluent mappings
    // in this assembly. Expensive to create, so it is registered as a singleton.
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory Build(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString)
                    .Driver<MicrosoftDataSqlClientDriver>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AssetMapping>())
                .BuildSessionFactory();
        }
    }
}
