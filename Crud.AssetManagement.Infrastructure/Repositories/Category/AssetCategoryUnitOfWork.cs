using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts.Category;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Category
{
    public class AssetCategoryUnitOfWork : UnitOfWork, IAssetCategoryUnitOfWork
    {
        public IAssetCategoryRepository AssetCategoryRepository { get; }

        public AssetCategoryUnitOfWork(ISession session, IAssetCategoryRepository assetCategoryRepository)
            : base(session)
        {
            AssetCategoryRepository = assetCategoryRepository;
        }
    }
}
