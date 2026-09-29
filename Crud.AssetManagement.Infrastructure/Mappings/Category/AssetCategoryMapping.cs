using FluentNHibernate.Mapping;
using Crud.AssetManagement.Infrastructure.Models.Category;

namespace Crud.AssetManagement.Infrastructure.Mappings.Category
{
    public class AssetCategoryMapping : ClassMap<AssetCategoryModel>
    {
        public AssetCategoryMapping()
        {
            Table("AssetCategory");
            Schema("Asset");

            Id(x => x.AssetCategoryId).Column("AssetCategoryId").GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.CreatedDate);
        }
    }
}
