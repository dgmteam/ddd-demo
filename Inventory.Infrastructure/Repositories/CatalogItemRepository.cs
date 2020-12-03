using System.Threading.Tasks;
using Inventory.Domain.CatalogItemAggregate;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly AppDbContext _dbContext;

        public CatalogItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<CatalogItem> Get(int id)
        {
            return await _dbContext.Set<CatalogItem>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(CatalogItem catalogItem)
        {
            await _dbContext.Set<CatalogItem>().AddAsync(catalogItem);
        }
    }
}