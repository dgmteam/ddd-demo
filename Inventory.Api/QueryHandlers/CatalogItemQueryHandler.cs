using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Inventory.Api.Queries;
using MediatR;

namespace Inventory.Api.QueryHandlers
{
    public class CatalogItemQueryHandler : IRequestHandler<CatalogItemQuery, CatalogItemViewModel>
    {
        private readonly IDbConnection _dbConnection;

        public CatalogItemQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<CatalogItemViewModel> Handle(CatalogItemQuery request, CancellationToken cancellationToken)
        {
            var catalogItem = await _dbConnection.QueryAsync<CatalogItemViewModel>(
                "select it.id, it.name, it.price_amount, it.price_currency, it.provider_id from catalog_items it left join catalog_providers p on it.provider_id = p.id where it.id = @id", new
                {
                    id = request.Id
                });
            return catalogItem.FirstOrDefault();
        }
    }
}