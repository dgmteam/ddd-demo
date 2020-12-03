using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, int>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly UnitOfWork _unitOfWork;

        public CreateCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository, UnitOfWork unitOfWork)
        {
            _catalogItemRepository = catalogItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var price = new Price(request.PriceAmount, request.PriceCurrency);
            var catalogItem = new CatalogItem(request.Name, price);
            await _catalogItemRepository.Add(catalogItem);
            await _unitOfWork.Commit();
            return catalogItem.Id;
        }
    }
}