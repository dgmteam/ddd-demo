using System.Collections.Generic;
using MediatR;

namespace Inventory.Api.Queries
{
    public class CatalogProviderQuery : IRequest<CatalogProviderViewModel>
    {
        public int Id { get; set; }
    }
}