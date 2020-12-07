namespace Inventory.Api.Dtos
{
    public class UpdateCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
        public int ProviderId { get; set; }
    }
}