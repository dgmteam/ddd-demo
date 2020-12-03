using System.Threading.Tasks;

namespace Inventory.Domain.CatalogItemAggregate
{
    public interface ICatalogItemRepository
    {
        Task<CatalogItem> Get(int id);
        Task Add(CatalogItem catalogItem);
    }
}