using System;

namespace Crud.AssetManagement.Infrastructure.Models.Asset
{
    // Note: properties are public (not protected-set) so the Commands/Mapper
    // AutoMapper profile can map straight from AddAssetCommand/UpdateAssetCommand
    // onto this model, matching the org's Commands.Mapper pattern. If you need
    // stricter encapsulation, revert to protected setters + Create()/Update()
    // and map through those methods instead.
    public class AssetModel
    {
        public virtual int AssetId { get; set; }
        public virtual int AssetTypeId { get; set; }
        public virtual int AssetCategoryId { get; set; }
        public virtual string AssetNo { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual string ModelNo { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual string AssetTagNo { get; set; }
        public virtual int ClientId { get; set; }
        public virtual string Location { get; set; }
        public virtual string Description { get; set; }
        public virtual string ThirdPartyName { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual decimal? ColorRate { get; set; }
        public virtual decimal? BwRate { get; set; }
        public virtual int? InitialColorMeter { get; set; }
        public virtual int? InitialBwMeter { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }

        public AssetModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public virtual void MarkUpdated()
        {
            UpdatedDate = DateTime.UtcNow;
        }

        public virtual void Delete()
        {
            DeletedDate = DateTime.UtcNow;
        }
    }
}
