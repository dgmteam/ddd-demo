using System.Threading.Tasks;

namespace Inventory.Domain.CatalogProviderAggregate
{
    public interface ICatalogProviderRepository
    {
        Task<CatalogProvider> Get(int id);
        Task Update(CatalogProvider catalogProvider);
        Task Remove(CatalogProvider catalogProvider);
        Task Add(CatalogProvider catalogProvider);
    }
}