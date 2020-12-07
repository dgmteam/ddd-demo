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
        
        public CatalogProvider(int id, string name, Address address) : this(name)
        {
            Id = id;
            Address = address;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}