namespace Inventory.Api.Dtos
{
    public class UpdateCatalogProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
    }
}