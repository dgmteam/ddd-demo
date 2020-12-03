namespace Inventory.Domain.CatalogItemAggregate
{
    public class Price : IValueObject
    {
        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj switch // pattern matching
            {
                null => false,
                Price p1 => Amount == p1.Amount && Currency == p1.Currency,
                _ => false
            };
        }
    }
}