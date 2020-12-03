using Inventory.Domain.CatalogItemAggregate;

namespace Inventory.Domain.OrderAggregate
{
    public class OrderLine : IEntity
    {
        public OrderLine(int sku, int quantity, Price unitPrice)
        {
            Sku = sku;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int Id { get; private set; }
        public int Sku { get; private set; }
        public int Quantity { get; private set; }
        public Price UnitPrice { get; private set; }

        public void Increase(in int quantity)
        {
            Quantity += quantity;
        }
    }
}