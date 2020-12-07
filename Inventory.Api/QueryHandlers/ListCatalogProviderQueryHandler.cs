using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Inventory.Api.Queries;
using MediatR;

namespace Inventory.Api.QueryHandlers
{
    public class ListCatalogProviderQueryHandler: IRequestHandler<ListCatalogProviderQuery, IList<CatalogProviderViewModel>>
    {
        private readonly IDbConnection _dbConnection;

        public  ListCatalogProviderQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IList<CatalogProviderViewModel>> Handle(ListCatalogProviderQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbConnection.QueryAsync<CatalogProviderViewModel>("select cp.id, cp.name, cp.address_line, cp.address_city from catalog_providers cp offset @skip limit @take", new
            {
                skip = request.Skip,
                take = request.Take
            });

            return list.AsList();
        }
    }
}