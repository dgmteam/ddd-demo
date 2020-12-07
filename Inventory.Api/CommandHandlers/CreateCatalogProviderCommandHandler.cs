using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class CreateCatalogProviderCommandHandler: IRequestHandler<CreateCatalogProviderCommand, int>
    {
        private readonly ICatalogProviderRepository _catalogProviderRepository;
        private readonly UnitOfWork _unitOfWork;

        public CreateCatalogProviderCommandHandler(ICatalogProviderRepository catalogItemRepository, UnitOfWork unitOfWork)
        {
            _catalogProviderRepository = catalogItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCatalogProviderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.AddressLine, request.City);
            var catalogProvider = new CatalogProvider(request.Name, address);
            await _catalogProviderRepository.Add(catalogProvider);
            await _unitOfWork.Commit();
            return catalogProvider.Id;
        }
    }
}