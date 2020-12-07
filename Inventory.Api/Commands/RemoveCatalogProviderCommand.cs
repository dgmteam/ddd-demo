using System;
using MediatR;

namespace Inventory.Api.Commands
{
    public class RemoveCatalogProviderCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}