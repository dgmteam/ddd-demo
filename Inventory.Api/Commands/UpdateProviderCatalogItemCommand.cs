using System;
using MediatR;

namespace Inventory.Api.Commands
{
    public class UpdateProviderCatalogItemCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
    }
}