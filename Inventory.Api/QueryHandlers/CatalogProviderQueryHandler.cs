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
    public class CatalogProviderQueryHandler : IRequestHandler<CatalogProviderQuery, CatalogProviderViewModel>
    {
        private readonly IDbConnection _dbConnection;

        public CatalogProviderQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<CatalogProviderViewModel> Handle(CatalogProviderQuery request, CancellationToken cancellationToken)
        {
            var catalogItem = await _dbConnection.QueryAsync<CatalogProviderViewModel>(
                "select it.id, it.name, it.address_line, it.address_city from catalog_providers it where it.id = @id", new
                {
                    id = request.Id
                });
            return catalogItem.FirstOrDefault();
        }
    }
}