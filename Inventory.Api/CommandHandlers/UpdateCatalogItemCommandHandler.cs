using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, int>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly ICatalogProviderRepository _catalogProviderRepository;
        private readonly UnitOfWork _unitOfWork;

        public UpdateCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository, ICatalogProviderRepository catalogProviderRepository, UnitOfWork unitOfWork)
        {
            _catalogItemRepository = catalogItemRepository;
            _catalogProviderRepository = catalogProviderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var provider = _catalogProviderRepository.Get(request.ProviderId);
            if (provider.Result == null) return -1;
            var price = new Price(request.PriceAmount, request.PriceCurrency);
            var catalogItem = new CatalogItem(request.Id, request.Name, price, request.ProviderId);
            _catalogItemRepository.Update(catalogItem);
            await _unitOfWork.Commit();
            return catalogItem.Id;
        }
    }
}