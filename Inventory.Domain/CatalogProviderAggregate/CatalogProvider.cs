namespace Inventory.Domain.CatalogProviderAggregate
{
    public class CatalogProvider : IEntity, IAggregateRoot
    {
        protected CatalogProvider(string name)
        {
            Name = name;
        }
        
        public CatalogProvider(string name, Address address) : this(name)
        {
            Address = address;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}