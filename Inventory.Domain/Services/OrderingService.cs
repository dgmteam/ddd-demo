using System.Threading.Tasks;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.OrderAggregate;

namespace Inventory.Domain.Services
{
    public class CheckoutService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;

        public CheckoutService(ICatalogItemRepository catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }
        
        public async Task<bool> AddSkuToOrder(Order order, int catalogItemId, int sku, int quantity)
        {
            var catalogItem = await _catalogItemRepository.Get(catalogItemId);

            if (catalogItem == null)
            {
                return false;
            }
            
            if (catalogItem.TryDecrease(sku, quantity))
            {
                order.Add(sku, quantity, catalogItem.Price);
                return true;
            }

            return false;
        }
    }
}