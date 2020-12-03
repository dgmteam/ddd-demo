using System;
using Inventory.Domain.CatalogItemAggregate;

namespace Inventory.Domain
{
    public class Address : IValueObject
    {
        public Address(string addressLine, string city)
        {
            AddressLine = addressLine;
            City = city;
        }

        public string AddressLine { get; private set; }
        public string City { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                Address a1 => Equals(a1),
                _ => false
            };
        }

        protected bool Equals(Address other)
        {
            return AddressLine == other.AddressLine && City == other.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AddressLine, City);
        }
    }
}