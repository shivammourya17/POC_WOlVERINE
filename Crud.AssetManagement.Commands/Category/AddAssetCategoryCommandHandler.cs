using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Crud.AssetManagement.Infrastructure.Contracts.Category;
using Crud.AssetManagement.Infrastructure.Models.Category;

namespace Crud.AssetManagement.Commands.Category
{
    public class AddAssetCategoryCommandHandler
    {
        private readonly IAssetCategoryUnitOfWork _assetCategoryUnitOfWork;

        public AddAssetCategoryCommandHandler(IAssetCategoryUnitOfWork assetCategoryUnitOfWork)
        {
            _assetCategoryUnitOfWork = assetCategoryUnitOfWork;
        }

        public async Task<Result<string>> Handle(AddAssetCategoryCommand request, Result validation, CancellationToken cancellationToken)
        {
            // Supplied by ValidateAssetCategoryDecorator (pre middleware).
            if (validation.IsFailure)
            {
                return Result.Failure<string>(validation.Error);
            }

            var model = new AssetCategoryModel { Name = request.Name };

            await _assetCategoryUnitOfWork.AssetCategoryRepository.SaveAsync(model);
            await _assetCategoryUnitOfWork.FlushAsync();

            return Result.Success(model.AssetCategoryId.ToString());
        }
    }
}
