using System.Threading.Tasks;
using AutoMapper;
using Wolverine;
using Microsoft.AspNetCore.Mvc;
using Crud.AssetManagement.Commands.Category;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.DTOs.Category;
using Crud.AssetManagement.Utils;

namespace Crud.AssetManagement.Controllers
{
    public class AssetCategoryController : BaseController
    {
        private readonly IMessageBus _bus;
        private readonly IMapper _mapper;

        public AssetCategoryController(IMessageBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetCategoryAsync([FromBody] AssetCategoryDto dto)
        {
            var result = await _bus.CommandDispatchAsync<AddAssetCategoryCommand, string>(_mapper, dto);
            return FromResult(result);
        }
    }
}
