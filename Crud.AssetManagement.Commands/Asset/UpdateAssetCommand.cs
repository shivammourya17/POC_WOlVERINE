using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Shared;

namespace Crud.AssetManagement.Commands.Asset
{
    public class UpdateAssetCommand : BaseAssetCommand, ICommand<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
