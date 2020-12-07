using MediatR;

namespace Inventory.Api.Commands
{
    public class CreateCatalogProviderCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
    }
}