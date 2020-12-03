using System.Collections.Generic;
using System.Linq;
using Inventory.Domain.CatalogItemAggregate;

namespace Inventory.Domain.OrderAggregate
{
    public class Order : IEntity
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public void Add(int sku, int quantity, Price unitPrice)
        {
            var line = Lines.FirstOrDefault(x => x.Sku == sku);

            if (line == null)
            {
                Lines.Add(new OrderLine(sku, quantity, unitPrice));
            }
            else
            {
                line.Increase(quantity);
            }
        }
        
        public int Id { get; private set; }
        public IList<OrderLine> Lines { get; private set; }
    }
}