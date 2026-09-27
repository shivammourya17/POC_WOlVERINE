using Wolverine;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Asset.Decorators;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class CommandsWolverineExtensions
    {
        public static WolverineOptions AddCommandHandlers(this WolverineOptions options)
        {
            // Wolverine only scans the entry assembly by default.
            options.Discovery.IncludeAssembly(typeof(CommandsWolverineExtensions).Assembly);

            options.Policies.AddMiddleware(typeof(ValidateAssetObjectDecorator),
                chain => chain.MessageType == typeof(AddAssetCommand));

            return options;
        }
    }
}
