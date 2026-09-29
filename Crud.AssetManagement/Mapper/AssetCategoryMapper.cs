using AutoMapper;
using Crud.AssetManagement.Commands.Category;
using Crud.AssetManagement.DTOs.Category;

namespace Crud.AssetManagement.Mapper
{
    public class AssetCategoryMapper : Profile
    {
        public AssetCategoryMapper()
        {
            CreateMap<AssetCategoryDto, AddAssetCategoryCommand>();
        }
    }
}
