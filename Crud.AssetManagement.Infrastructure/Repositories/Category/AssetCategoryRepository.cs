using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Crud.AssetManagement.Infrastructure.Contracts.Category;
using Crud.AssetManagement.Infrastructure.Models.Category;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Category
{
    public class AssetCategoryRepository : BaseRepository<AssetCategoryModel>, IAssetCategoryRepository
    {
        public AssetCategoryRepository(ISession session)
            : base(session)
        {
        }

        public async Task SaveAsync(AssetCategoryModel model)
        {
            await AddAsync(model);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Session.Query<AssetCategoryModel>()
                .AnyAsync(model => model.Name == name);
        }

        public async Task SaveAuditAsync(AssetCategoryAuditModel audit)
        {
            await Session.SaveAsync(audit);
        }
    }
}
