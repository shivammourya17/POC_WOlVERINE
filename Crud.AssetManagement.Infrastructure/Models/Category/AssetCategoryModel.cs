using System;

namespace Crud.AssetManagement.Infrastructure.Models.Category
{
    public class AssetCategoryModel
    {
        public virtual int AssetCategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public AssetCategoryModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
