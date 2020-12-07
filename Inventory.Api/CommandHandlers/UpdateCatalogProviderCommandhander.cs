using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class UpdateCatalogProviderCommandHandler: IRequestHandler<UpdateCatalogProviderCommand, int>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ICatalogProviderRepository _catalogProviderRepository;

        public UpdateCatalogProviderCommandHandler(ICatalogProviderRepository catalogProviderRepository, UnitOfWork unitOfWork)
        {
            _catalogProviderRepository = catalogProviderRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> Handle(UpdateCatalogProviderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.AddressLine, request.City);
            var catalogProvider = new CatalogProvider(request.Id, request.Name, address);
            _catalogProviderRepository.Update(catalogProvider);
            await _unitOfWork.Commit();
            return catalogProvider.Id;
        }
    }
}