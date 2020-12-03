using System.Collections.Generic;
using MediatR;

namespace Inventory.Api.Queries
{
    public class ListCatalogItemQuery : IRequest<IList<CatalogItemModel>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class CatalogItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }
    }
}