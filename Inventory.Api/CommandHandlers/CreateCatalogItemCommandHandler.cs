using System;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, int>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ICatalogProviderRepository _catalogProviderRepository;

        public CreateCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository, ICatalogProviderRepository catalogProviderRepository, UnitOfWork unitOfWork)
        {
            _catalogItemRepository = catalogItemRepository;
            _catalogProviderRepository = catalogProviderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var provider = await _catalogProviderRepository.Get(request.ProviderId);
            if (provider == null) return -1;
            var price = new Price(request.PriceAmount, request.PriceCurrency);
            var catalogItem = new CatalogItem(request.Name, price, request.ProviderId);
            await _catalogItemRepository.Add(catalogItem);
            await _unitOfWork.Commit();
            return catalogItem.Id;
        }
    }
}