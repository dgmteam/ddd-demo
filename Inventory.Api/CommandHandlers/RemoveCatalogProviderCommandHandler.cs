using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Commands;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;

namespace Inventory.Api.CommandHandlers
{
    public class RemoveCatalogProviderCommandHandler : IRequestHandler<RemoveCatalogProviderCommand, int>
    {
        private readonly ICatalogProviderRepository _catalogProviderRepository;
        private readonly UnitOfWork _unitOfWork;

        public RemoveCatalogProviderCommandHandler(ICatalogProviderRepository catalogProviderRepository, UnitOfWork unitOfWork)
        {
            _catalogProviderRepository = catalogProviderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RemoveCatalogProviderCommand request, CancellationToken cancellationToken)
        {
            _catalogProviderRepository.Remove(request.Id);
            await _unitOfWork.Commit();
            return request.Id;
        }
    }
}