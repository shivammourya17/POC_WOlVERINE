using CSharpFunctionalExtensions;
using Crud.AssetManagement.Commands.Shared;

namespace Crud.AssetManagement.Commands.Category
{
    public class AddAssetCategoryCommand : ICommand<Result<string>>
    {
        public string Name { get; set; }
    }
}
