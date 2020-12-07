using System.Linq;
using System.Threading.Tasks;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure
{
    public class CatalogProviderRepository : ICatalogProviderRepository
    {
        private readonly AppDbContext _dbContext;

        public CatalogProviderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<CatalogProvider> Get(int id)
        {
            return await _dbContext.Set<CatalogProvider>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(CatalogProvider catalogProvider)
        {
            var item = _dbContext.Set<CatalogProvider>().FirstOrDefault(c => c.Id == catalogProvider.Id);
            item?.UpdateAddress(catalogProvider.Address);
            item?.UpdateName(catalogProvider.Name);
        }

        public void Remove(int id)
        {
            var item = _dbContext.Set<CatalogProvider>().FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _dbContext.Set<CatalogProvider>().Remove(item);
            }
        }

        public async Task Add(CatalogProvider catalogProvider)
        {
            await _dbContext.Set<CatalogProvider>().AddAsync(catalogProvider);
        }
    }
}