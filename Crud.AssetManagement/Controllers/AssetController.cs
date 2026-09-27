using System.Threading.Tasks;
using AutoMapper;
using Wolverine;
using Microsoft.AspNetCore.Mvc;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.DTOs.Asset;
using Crud.AssetManagement.Queries.Asset.GetAssetList;
using Crud.AssetManagement.Queries.Extensions;
using Crud.AssetManagement.Integration.Contracts.Asset;
using Crud.AssetManagement.Utils;

namespace Crud.AssetManagement.Controllers
{
    public class AssetController : BaseController
    {
        private readonly IMessageBus _bus;
        private readonly IMapper _mapper;
        private readonly IAssetAppServices _assetAppServices;

        public AssetController(IMessageBus bus, IMapper mapper, IAssetAppServices assetAppServices)
        {
            _bus = bus;
            _mapper = mapper;
            _assetAppServices = assetAppServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetAsync([FromBody] AssetDto dto)
        {
            var result = await _bus.CommandDispatchAsync<AddAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssetAsync(int id, [FromBody] AssetDto dto)
        {
            dto.AssetId = id;
            var result = await _bus.CommandDispatchAsync<UpdateAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetAsync(int id)
        {
            var dto = new AssetDto { AssetId = id };
            var result = await _bus.CommandDispatchAsync<DeleteAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetByIdAsync(int id)
        {
            var result = await _assetAppServices.GetAssetByIdAsync(id);
            return FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetListAsync([FromQuery] int perPage, [FromQuery] int page, [FromQuery] string q = null, [FromQuery] int? clientId = null)
        {
            var query = new GetAssetListQuery(perPage, page, q, clientId);
            var result = await _bus.QueryDispatchAsync(query);
            return FromResult(result);
        }
    }
}
