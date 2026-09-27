using AutoMapper;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Commands.Mapper
{
    // Maps commands straight onto the domain model, matching the org's
    // Commands/Mapper pattern (as opposed to the API-layer Mapper, which
    // maps DTO -> Command).
    public class AssetMapper : Profile
    {
        public AssetMapper()
        {
            CreateMap<AddAssetCommand, AssetModel>()
                .ForMember(dest => dest.AssetId, opt => opt.Ignore())
                .ForMember(dest => dest.InitialColorMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialColorMeter : (int?)null))
                .ForMember(dest => dest.InitialBwMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialBwMeter : (int?)null));

            // AssetId is NHibernate's identifier and CreatedDate is set once on insert;
            // neither may be overwritten on a loaded entity.
            CreateMap<UpdateAssetCommand, AssetModel>()
                .ForMember(dest => dest.AssetId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.InitialColorMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialColorMeter : (int?)null))
                .ForMember(dest => dest.InitialBwMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialBwMeter : (int?)null));
        }
    }
}
