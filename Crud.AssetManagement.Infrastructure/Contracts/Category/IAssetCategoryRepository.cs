using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Models.Category;

namespace Crud.AssetManagement.Infrastructure.Contracts.Category
{
    public interface IAssetCategoryRepository
    {
        Task SaveAsync(AssetCategoryModel model);
        Task<bool> ExistsByNameAsync(string name);
        Task SaveAuditAsync(AssetCategoryAuditModel audit);
    }
}
