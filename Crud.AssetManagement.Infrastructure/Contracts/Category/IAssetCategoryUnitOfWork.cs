namespace Crud.AssetManagement.Infrastructure.Contracts.Category
{
    public interface IAssetCategoryUnitOfWork : IUnitOfWork
    {
        IAssetCategoryRepository AssetCategoryRepository { get; }
    }
}
