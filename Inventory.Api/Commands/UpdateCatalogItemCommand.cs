using System;
using MediatR;

namespace Inventory.Api.Commands
{
    public class UpdateCatalogItemCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
        public int ProviderId { get; set; }
    }
}