using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;

namespace Crud.AssetManagement.Commands.Asset
{
    public class DeleteAssetCommandHandler
    {
        private readonly IAssetUnitOfWork _assetUnitOfWork;

        public DeleteAssetCommandHandler(IAssetUnitOfWork assetUnitOfWork)
        {
            _assetUnitOfWork = assetUnitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            var model = await _assetUnitOfWork.AssetRepository.GetByIdAsync(request.AssetId);

            if (model == null)
            {
                return Result.Failure<string>(string.Format(CommandMessageResource.NOT_EXISTS, "Asset"));
            }

            model.Delete();

            await _assetUnitOfWork.FlushAsync();

            return Result.Success(model.AssetId.ToString());
        }
    }
}
