using System.Threading;
using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Contracts;
using Crud.AssetManagement.Queries.Shared;

namespace Crud.AssetManagement.Queries.Asset.GetAssetById
{
    public class GetAssetByIdQueryHandler : BaseQueryHandler
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public GetAssetByIdQueryHandler(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<GetAssetByIdQueryResult> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
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
                            A.BwRate,
                            A.InitialColorMeter,
                            A.InitialBwMeter
                        FROM Asset.Asset A WITH (NOLOCK)
                        WHERE
                            1 = 1
                            AND A.DeletedDate IS NULL
                            AND A.AssetId = @AssetId";

            var queryBuilder = new QueryBuilder(sql)
                .SetParameter("AssetId", request.AssetId);

            return await queryBuilder.ExecuteSingleAsync<GetAssetByIdQueryResult>(_connectionFactory);
        }
    }
}
