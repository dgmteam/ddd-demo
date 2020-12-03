using System.Collections.Generic;
using System.Linq;

namespace Inventory.Domain.CatalogItemAggregate
{
    // Domain model
    public class CatalogItem : IEntity, IAggregateRoot
    {
        protected CatalogItem(string name)
        {
            Name = name;
        }
        
        public CatalogItem(string name, Price price) : this(name)
        {
            Skus = new List<Sku>();
            Price = price;
        }

        public void AddSku(string name)
        {
            Skus.Add(new Sku(name));
        }

        public void RemoveSku(int id)
        {
            Skus.Remove(Skus.First(x => x.Id == id));
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void UpdateSku(int id, string name)
        {
            var sku = Skus.FirstOrDefault(x => x.Id == id);
            sku?.Update(name);
        }

        public bool TryDecrease(int skuId, int number)
        {
            var sku = Skus.FirstOrDefault(x => x.Id == skuId);
            return sku != null && sku.TryDecrease(number);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual IList<Sku> Skus { get; private set; }
        public virtual Price Price { get; private set; } // = 100USD
    }
}