using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace Inventory.Api.Queries
{
    public class ListCatalogProviderQuery: IRequest<IList<CatalogProviderViewModel>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
    public class CatalogProviderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string AddressCity { get; set; }
    }
}