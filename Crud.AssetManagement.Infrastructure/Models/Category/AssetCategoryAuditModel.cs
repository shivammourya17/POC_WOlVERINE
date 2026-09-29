using System;

namespace Crud.AssetManagement.Infrastructure.Models.Category
{
    // One row per AddAssetCategoryCommand, written by the post decorator
    // (AuditAssetCategoryDecorator) whether the command succeeded or not.
    public class AssetCategoryAuditModel
    {
        public virtual int AuditId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsSuccess { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public AssetCategoryAuditModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
