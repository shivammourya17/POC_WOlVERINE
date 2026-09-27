using System.Threading;
using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Contracts;
using Crud.AssetManagement.Queries.Shared;

namespace Crud.AssetManagement.Queries.Asset.GetAssetList
{
    public class GetAssetListQueryHandler : BaseQueryHandler
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public GetAssetListQueryHandler(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<GetAssetListQueryResult> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
        {
            var sql = @"SELECT
                            A.AssetId,
                            A.AssetTypeId,
                            A.AssetCategoryId,
                            A.AssetNo,
                            A.Manufacturer,
                            A.ModelNo,
                            A.SerialNo,
                            A.AssetTagNo,
                            A.ClientId,
                            A.Location,
                            A.Description,
                            A.ThirdPartyName,
                            A.PhoneNo,
                            A.EmailAddress,
                            A.ColorRate,
                            A.BwRate
                        FROM Asset.Asset A WITH (NOLOCK)
                        WHERE
                            1 = 1
                            AND A.DeletedDate IS NULL";

            var offset = (request.Page - 1) * request.PerPage;

            var queryBuilder = new QueryBuilder(sql)
                .AppendLineIf(request.ClientId.HasValue && request.ClientId > 0, " AND A.ClientId = @ClientId")
                .SetConditionalParameter("ClientId", request.ClientId)

                .AppendLineIf(!string.IsNullOrEmpty(request.Q), @" AND (
                                              A.AssetNo LIKE '%' + @Q + '%'
                                              OR A.Manufacturer LIKE '%' + @Q + '%'
                                              OR A.SerialNo LIKE '%' + @Q + '%'
                                              OR A.AssetTagNo LIKE '%' + @Q + '%'
                                              OR A.Location LIKE '%' + @Q + '%')")
                .SetConditionalParameter("Q", request.Q)

                .AppendLine(" ORDER BY A.AssetId DESC")
                .AppendLine(" OFFSET @Offset ROWS FETCH NEXT @PerPage ROWS ONLY")
                .SetParameter("Offset", offset)
                .SetParameter("PerPage", request.PerPage);

            var items = await queryBuilder.ExecuteListAsync<AssetListItem>(_connectionFactory);

            return new GetAssetListQueryResult
            {
                Items = items
            };
        }
    }
}
