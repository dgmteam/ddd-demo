using System.Threading.Tasks;

namespace Inventory.Domain.CatalogProviderAggregate
{
    public interface ICatalogProviderRepository
    {
        Task<CatalogProvider> Get(int id);
        void Update(CatalogProvider catalogProvider);
        void Remove(int id);
        Task Add(CatalogProvider catalogProvider);
    }
}