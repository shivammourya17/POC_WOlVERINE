using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Shared;

namespace Crud.AssetManagement.Commands.Asset
{
    public class AddAssetCommand : BaseAssetCommand, ICommand<Result<string>>
    {
    }
}
