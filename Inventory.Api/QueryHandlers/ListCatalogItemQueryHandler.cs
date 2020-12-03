using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Inventory.Api.Queries;
using MediatR;

namespace Inventory.Api.QueryHandlers
{
    public class ListCatalogItemQueryHandler : IRequestHandler<ListCatalogItemQuery, IList<CatalogItemModel>>
    {
        private readonly IDbConnection _dbConnection;

        public ListCatalogItemQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<IList<CatalogItemModel>> Handle(ListCatalogItemQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbConnection.QueryAsync<CatalogItemModel>(
                "select it.*, p.name as provider_name from catalog_items it left join catalog_item_providers p on it.provider_id = p.id offset @skip limit @take", new
                {
                    skip = request.Skip,
                    take = request.Take
                });

            return list.AsList();
        }
    }
}