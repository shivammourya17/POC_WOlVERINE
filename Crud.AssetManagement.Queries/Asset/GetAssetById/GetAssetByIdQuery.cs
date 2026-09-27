using Crud.AssetManagement.Queries.Shared;

namespace Crud.AssetManagement.Queries.Asset.GetAssetById
{
    public class GetAssetByIdQuery : IQuery<GetAssetByIdQueryResult>
    {
        public int AssetId { get; }

        public GetAssetByIdQuery(int assetId)
        {
            AssetId = assetId;
        }
    }
}
