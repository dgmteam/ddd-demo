using System;
using MediatR;

namespace Inventory.Api.Commands
{
    public class RemoveCatalogItemCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}