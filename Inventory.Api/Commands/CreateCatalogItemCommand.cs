using System;
using MediatR;

namespace Inventory.Api.Commands
{
    public class CreateCatalogItemCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
    }
}