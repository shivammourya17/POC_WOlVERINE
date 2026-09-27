using Crud.AssetManagement.Queries.Shared;

namespace Crud.AssetManagement.Queries.Asset.GetAssetList
{
    public class GetAssetListQuery : BaseQueryPagination, IQuery<GetAssetListQueryResult>
    {
        public int? ClientId { get; set; }

        public GetAssetListQuery(int perPage, int page, string q = null, int? clientId = null)
        {
            PerPage = perPage > 0 ? perPage : 10;
            Page = page > 0 ? page : 1;
            Q = q;
            ClientId = clientId;
        }
    }
}
