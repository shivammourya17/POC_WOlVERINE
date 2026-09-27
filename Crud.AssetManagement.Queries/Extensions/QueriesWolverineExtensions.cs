using Wolverine;

namespace Crud.AssetManagement.Queries.Extensions
{
    public static class QueriesWolverineExtensions
    {
        public static WolverineOptions AddQueryHandlers(this WolverineOptions options)
        {
            // Wolverine only scans the entry assembly by default.
            options.Discovery.IncludeAssembly(typeof(QueriesWolverineExtensions).Assembly);

            return options;
        }
    }
}
