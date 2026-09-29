using FluentNHibernate.Mapping;
using Crud.AssetManagement.Infrastructure.Models.Category;

namespace Crud.AssetManagement.Infrastructure.Mappings.Category
{
    public class AssetCategoryAuditMapping : ClassMap<AssetCategoryAuditModel>
    {
        public AssetCategoryAuditMapping()
        {
            Table("AssetCategoryAudit");
            Schema("Asset");

            Id(x => x.AuditId).Column("AuditId").GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.IsSuccess);
            Map(x => x.Message);
            Map(x => x.CreatedDate);
        }
    }
}
