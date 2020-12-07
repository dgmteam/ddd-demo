using System.Collections.Generic;
using MediatR;

namespace Inventory.Api.Queries
{
    public class CatalogItemQuery : IRequest<CatalogItemViewModel>
    {
        public int Id { get; set; }
    }
}