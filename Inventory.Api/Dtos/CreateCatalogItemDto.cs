namespace Inventory.Api.Dtos
{
    public class CreateCatalogItemDto
    {
        public string Name { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
    }
}