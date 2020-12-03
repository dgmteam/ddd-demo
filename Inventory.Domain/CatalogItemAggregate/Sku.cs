namespace Inventory.Domain.CatalogItemAggregate
{
    public class Sku : IEntity
    {
        public Sku(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int InStock { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }

        public bool TryDecrease(int number)
        {
            if (InStock < number)
            {
                return false;
            }

            InStock -= number;
            return true;
        }
    }
}