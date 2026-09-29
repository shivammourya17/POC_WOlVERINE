using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.Infrastructure.Contracts.Category;

namespace Crud.AssetManagement.Commands.Category.Decorators
{
    // Wolverine "pre" middleware: runs before AddAssetCategoryCommandHandler and checks the
    // database (through NHibernate) for a category with the same name.
    //
    // Wolverine resolves IAssetCategoryUnitOfWork from the same per-message scope as the
    // handler, so this decorator, the handler and the post decorator share one ISession.
    public static class ValidateAssetCategoryDecorator
    {
        public static async Task<Result> Before(AddAssetCategoryCommand request, IAssetCategoryUnitOfWork assetCategoryUnitOfWork)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Result.Failure(CommandMessageResource.NAME_REQUIRED);
            }

            request.Name = request.Name.Trim();

            if (await assetCategoryUnitOfWork.AssetCategoryRepository.ExistsByNameAsync(request.Name))
            {
                return Result.Failure(string.Format(CommandMessageResource.ALREADY_EXISTS, "Asset category"));
            }

            return Result.Success();
        }
    }
}
