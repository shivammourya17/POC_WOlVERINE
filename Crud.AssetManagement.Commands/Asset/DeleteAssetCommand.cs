using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Shared;

namespace Crud.AssetManagement.Commands.Asset
{
    public class DeleteAssetCommand : ICommand<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
