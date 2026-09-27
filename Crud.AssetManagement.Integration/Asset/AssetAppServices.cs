using System.Threading.Tasks;
using Wolverine;
using Crud.AssetManagement.Integration.Contracts.Asset;
using Crud.AssetManagement.Queries.Asset.GetAssetById;

namespace Crud.AssetManagement.Integration.Asset
{
    public class AssetAppServices : IAssetAppServices
    {
        private readonly IMessageBus _bus;

        public AssetAppServices(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task<GetAssetByIdQueryResult> GetAssetByIdAsync(int assetId)
        {
            return await _bus.InvokeAsync<GetAssetByIdQueryResult>(new GetAssetByIdQuery(assetId));
        }
    }
}
