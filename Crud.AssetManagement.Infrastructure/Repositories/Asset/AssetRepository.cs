using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Models.Asset;
using Crud.AssetManagement.Infrastructure.Specification.Asset;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Asset
{
    public class AssetRepository : BaseRepository<AssetModel>, IAssetRepository
    {
        public AssetRepository(ISession session)
            : base(session)
        {
        }

        public async Task SaveAsync(AssetModel model)
        {
            await AddAsync(model);
        }

        // Excludes soft-deleted assets.
        public async Task<AssetModel> GetByIdAsync(int id)
        {
            return await FindAsync(new GetAssetByIdSpecification(id));
        }

        public async Task<IList<AssetModel>> GetListAsync(int perPage, int page)
        {
            var query = Session.Query<AssetModel>()
                .Where(model => model.DeletedDate == null)
                .OrderByDescending(model => model.AssetId);

            return await FindListAsync(query, perPage, page);
        }

        public async Task FlushAsync()
        {
            await SaveChangesAsync();
        }
    }
}
