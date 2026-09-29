using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Crud.AssetManagement.Infrastructure.Contracts.Category;
using Crud.AssetManagement.Infrastructure.Models.Category;

namespace Crud.AssetManagement.Commands.Category.Decorators
{
    // Wolverine "post" middleware: runs after AddAssetCategoryCommandHandler and receives the
    // handler's Result<string>. Writes one Asset.AssetCategoryAudit row through NHibernate for
    // every request, including ones the pre decorator rejected.
    //
    // Not run if the handler throws (use Finally for that); cannot change the returned Result.
    public static class AuditAssetCategoryDecorator
    {
        public static async Task After(AddAssetCategoryCommand request, Result<string> result, IAssetCategoryUnitOfWork assetCategoryUnitOfWork)
        {
            var audit = new AssetCategoryAuditModel
            {
                Name = request.Name,
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess ? $"Created AssetCategoryId {result.Value}" : result.Error
            };

            await assetCategoryUnitOfWork.AssetCategoryRepository.SaveAuditAsync(audit);
            await assetCategoryUnitOfWork.FlushAsync();
        }
    }
}
