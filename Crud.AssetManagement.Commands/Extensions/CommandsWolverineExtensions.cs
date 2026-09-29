using Wolverine;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Asset.Decorators;
using Crud.AssetManagement.Commands.Category;
using Crud.AssetManagement.Commands.Category.Decorators;

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

            // Pre/post pair for AddAssetCategoryCommand: Before runs ahead of the handler, After behind it.
            options.Policies.AddMiddleware(typeof(ValidateAssetCategoryDecorator),
                chain => chain.MessageType == typeof(AddAssetCategoryCommand));
            options.Policies.AddMiddleware(typeof(AuditAssetCategoryDecorator),
                chain => chain.MessageType == typeof(AddAssetCategoryCommand));

            return options;
        }
    }
}
