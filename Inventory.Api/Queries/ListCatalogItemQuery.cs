using System.Collections.Generic;
using MediatR;

namespace Inventory.Api.Queries
{
    public class ListCatalogItemQuery : IRequest<IList<CatalogItemViewModel>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
        public int ProviderId { get; set; }
    }
}