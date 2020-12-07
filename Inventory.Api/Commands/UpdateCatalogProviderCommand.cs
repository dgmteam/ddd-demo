using MediatR;

namespace Inventory.Api.Commands
{
    public class UpdateCatalogProviderCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
    }
}